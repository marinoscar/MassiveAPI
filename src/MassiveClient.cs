using System.Net;
using System.Net.Http.Headers;
using System.Text;
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

        var endpoint = $"stocks/tickers/{Uri.EscapeDataString(request.Ticker)}/overview";
        return await SendAsync<TickerOverviewResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve the ticker overview from the Massive API.",
                "Failed to deserialize the ticker overview response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Retrieves aggregated custom bar data for a ticker over a specified time range.
    /// </summary>
    /// <param name="request">The request describing the aggregation parameters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The custom bars response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="ArgumentException">
    /// Thrown when required request fields are missing or invalid.
    /// </exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    public async Task<CustomBarsResponse> GetCustomBarsAsync(
        CustomBarsRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (string.IsNullOrWhiteSpace(request.Ticker))
        {
            throw new ArgumentException("Ticker is required.", nameof(request));
        }

        if (request.Multiplier is null || request.Multiplier <= 0)
        {
            throw new ArgumentException("Multiplier must be greater than zero.", nameof(request));
        }

        if (string.IsNullOrWhiteSpace(request.Timespan))
        {
            throw new ArgumentException("Timespan is required.", nameof(request));
        }

        if (request.From is null || request.To is null)
        {
            throw new ArgumentException("Both from and to timestamps are required.", nameof(request));
        }

        var endpoint = "stocks/aggregates/custom-bars";
        var payload = JsonSerializer.Serialize(request, SerializerOptions);
        var content = new StringContent(payload, Encoding.UTF8, "application/json");
        return await SendAsync<CustomBarsResponse>(
                HttpMethod.Post,
                endpoint,
                content,
                "Failed to retrieve custom bars from the Massive API.",
                "Failed to deserialize the custom bars response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Retrieves all tickers with optional filtering and pagination.
    /// </summary>
    /// <param name="request">The request describing ticker filters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The all tickers response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    public async Task<AllTickersResponse> GetAllTickersAsync(
        AllTickersRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = BuildQueryString(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? "stocks/tickers"
            : $"stocks/tickers?{queryString}";

        return await SendAsync<AllTickersResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve tickers from the Massive API.",
                "Failed to deserialize the tickers response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Retrieves aggregated custom bar data for an options ticker over a specified time range.
    /// </summary>
    /// <param name="request">The request describing the aggregation parameters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The options custom bars response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="ArgumentException">
    /// Thrown when required request fields are missing or invalid.
    /// </exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    public async Task<OptionsCustomBarsResponse> GetOptionsCustomBarsAsync(
        OptionsCustomBarsRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (string.IsNullOrWhiteSpace(request.Ticker))
        {
            throw new ArgumentException("Ticker is required.", nameof(request));
        }

        if (request.Multiplier is null || request.Multiplier <= 0)
        {
            throw new ArgumentException("Multiplier must be greater than zero.", nameof(request));
        }

        if (string.IsNullOrWhiteSpace(request.Timespan))
        {
            throw new ArgumentException("Timespan is required.", nameof(request));
        }

        if (request.From is null || request.To is null)
        {
            throw new ArgumentException("Both from and to timestamps are required.", nameof(request));
        }

        var endpoint = "options/aggregates/custom-bars";
        var payload = JsonSerializer.Serialize(request, SerializerOptions);
        var content = new StringContent(payload, Encoding.UTF8, "application/json");
        return await SendAsync<OptionsCustomBarsResponse>(
                HttpMethod.Post,
                endpoint,
                content,
                "Failed to retrieve options custom bars from the Massive API.",
                "Failed to deserialize the options custom bars response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    private async Task<TResponse> SendAsync<TResponse>(
        HttpMethod method,
        string endpoint,
        HttpContent? content,
        string requestErrorMessage,
        string deserializationErrorMessage,
        CancellationToken cancellationToken)
        where TResponse : class, new()
    {
        try
        {
            using var request = new HttpRequestMessage(method, endpoint)
            {
                Content = content
            };
            using var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
            var payload = await JsonSerializer.DeserializeAsync<TResponse>(stream, SerializerOptions, cancellationToken)
                .ConfigureAwait(false);

            return payload ?? new TResponse();
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            throw new MassiveApiException(requestErrorMessage, ex);
        }
        catch (JsonException ex)
        {
            throw new MassiveApiException(deserializationErrorMessage, ex);
        }
        catch (OperationCanceledException ex)
        {
            throw new MassiveApiException("The Massive API request timed out.", ex);
        }
    }

    private static string BuildQueryString(AllTickersRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "ticker", request.Ticker);
        AddParameter(parameters, "market", request.Market);
        AddParameter(parameters, "locale", request.Locale);
        AddParameter(parameters, "type", request.Type);
        AddParameter(parameters, "search", request.Search);
        AddParameter(parameters, "active", request.Active?.ToString().ToLowerInvariant());
        AddParameter(parameters, "sort", request.Sort);
        AddParameter(parameters, "order", request.Order);
        AddParameter(parameters, "limit", request.Limit?.ToString());
        AddParameter(parameters, "cursor", request.Cursor);

        return string.Join("&", parameters);
    }

    private static void AddParameter(ICollection<string> parameters, string name, string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return;
        }

        parameters.Add($"{WebUtility.UrlEncode(name)}={WebUtility.UrlEncode(value)}");
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
