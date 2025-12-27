using System.Net.Http.Headers;
using System.Text.Json;
using MassiveAPI.Requests;
using MassiveAPI.Responses;

namespace MassiveAPI;

/// <summary>
/// Provides a typed client for accessing the Massive API.
/// </summary>
public sealed class MassiveClient : IDisposable
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly HttpClient _httpClient;
    private readonly bool _disposeClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="MassiveClient"/> class using the provided API key
    /// and default client settings.
    /// </summary>
    /// <param name="apiKey">The Massive API key.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="apiKey"/> is null or whitespace.</exception>
    public MassiveClient(string apiKey)
        : this(apiKey, httpClient: null, baseUri: null, apiKeyHeaderName: "X-API-Key")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MassiveClient"/> class with custom client settings.
    /// </summary>
    /// <param name="apiKey">The Massive API key.</param>
    /// <param name="httpClient">An optional <see cref="HttpClient"/> to use for requests.</param>
    /// <param name="baseUri">An optional base URI for the Massive API.</param>
    /// <param name="apiKeyHeaderName">The header name used to send the API key.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="apiKey"/> or <paramref name="apiKeyHeaderName"/> is null or whitespace.
    /// </exception>
    public MassiveClient(
        string apiKey,
        HttpClient? httpClient = null,
        Uri? baseUri = null,
        string apiKeyHeaderName = "X-API-Key")
    {
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new ArgumentException("API key is required.", nameof(apiKey));
        }

        if (string.IsNullOrWhiteSpace(apiKeyHeaderName))
        {
            throw new ArgumentException("API key header name is required.", nameof(apiKeyHeaderName));
        }

        _disposeClient = httpClient is null;
        _httpClient = httpClient ?? new HttpClient();
        _httpClient.BaseAddress = baseUri ?? new Uri("https://api.massive.com/");

        _httpClient.DefaultRequestHeaders.Remove(apiKeyHeaderName);
        _httpClient.DefaultRequestHeaders.Add(apiKeyHeaderName, apiKey);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    /// <summary>
    /// Retrieves the overview data for a single ticker.
    /// </summary>
    /// <param name="request">The request describing the ticker to load.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The ticker overview response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    public async Task<TickerOverviewResponse> GetTickerOverviewAsync(
        TickerOverviewRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        try
        {
            var endpoint = $"stocks/tickers/{Uri.EscapeDataString(request.Ticker)}/overview";
            using var response = await _httpClient.GetAsync(endpoint, cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
            var payload = await JsonSerializer.DeserializeAsync<TickerOverviewResponse>(stream, SerializerOptions, cancellationToken)
                .ConfigureAwait(false);

            return payload ?? new TickerOverviewResponse();
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            throw new MassiveApiException("Failed to retrieve the ticker overview from the Massive API.", ex);
        }
        catch (JsonException ex)
        {
            throw new MassiveApiException("Failed to deserialize the ticker overview response from the Massive API.", ex);
        }
        catch (OperationCanceledException ex)
        {
            throw new MassiveApiException("The Massive API request timed out.", ex);
        }
    }

    /// <summary>
    /// Releases resources used by the client instance.
    /// </summary>
    public void Dispose()
    {
        if (_disposeClient)
        {
            _httpClient.Dispose();
        }
    }
}
