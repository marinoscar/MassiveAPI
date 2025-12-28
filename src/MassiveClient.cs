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
public sealed class MassiveClient : IMassiveClient
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly string _apiKey;
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

        _apiKey = apiKey;
        _disposeClient = httpClient is null;
        _httpClient = httpClient ?? new HttpClient();
        _httpClient.BaseAddress = baseUri ?? new Uri("https://api.massive.com/v3/reference/");

        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    /// <inheritdoc />
    public async Task<TickerOverviewResponse> GetTickerOverviewAsync(
        TickerOverviewRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var endpoint = $"tickers/{Uri.EscapeDataString(request.Ticker)}";
        return await SendAsync<TickerOverviewResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve the ticker overview from the Massive API.",
                "Failed to deserialize the ticker overview response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
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

    /// <inheritdoc />
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
            ? "tickers"
            : $"tickers?{queryString}";

        return await SendAsync<AllTickersResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve tickers from the Massive API.",
                "Failed to deserialize the tickers response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
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

    /// <inheritdoc />
    public async Task<OptionsContractOverviewResponse> GetOptionsContractOverviewAsync(
        OptionsContractOverviewRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var optionsTicker = request.OptionsTickerValue;
        if (string.IsNullOrWhiteSpace(optionsTicker))
        {
            throw new ArgumentException("Options ticker is required.", nameof(request));
        }

        var endpoint = $"options/contracts/{Uri.EscapeDataString(optionsTicker)}";
        return await SendAsync<OptionsContractOverviewResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve the options contract overview from the Massive API.",
                "Failed to deserialize the options contract overview response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<OptionsContractsResponse> GetOptionsContractsAsync(
        OptionsContractsRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = BuildQueryString(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? "options/contracts"
            : $"options/contracts?{queryString}";

        return await SendAsync<OptionsContractsResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve options contracts from the Massive API.",
                "Failed to deserialize the options contracts response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<TickerTypesResponse> GetTickerTypesAsync(
        TickerTypesRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = BuildQueryString(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? "tickers/types"
            : $"tickers/types?{queryString}";

        return await SendAsync<TickerTypesResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve ticker types from the Massive API.",
                "Failed to deserialize the ticker types response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<RelatedTickersResponse> GetRelatedTickersAsync(
        RelatedTickersRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var endpoint = $"tickers/{Uri.EscapeDataString(request.Ticker)}/related";
        return await SendAsync<RelatedTickersResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve related tickers from the Massive API.",
                "Failed to deserialize the related tickers response from the Massive API.",
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
            var requestUri = AppendApiKey(endpoint);
            using var request = new HttpRequestMessage(method, requestUri)
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

    private string AppendApiKey(string endpoint)
    {
        var separator = endpoint.Contains('?') ? "&" : "?";
        return $"{endpoint}{separator}apiKey={Uri.EscapeDataString(_apiKey)}";
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

    private static string BuildQueryString(OptionsContractsRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "ticker", request.Ticker);
        AddParameter(parameters, "underlying_ticker", request.UnderlyingTicker);
        AddParameter(parameters, "contract_type", request.ContractType);
        AddParameter(parameters, "expiration_date", request.ExpirationDate?.ToString("yyyy-MM-dd"));
        AddParameter(parameters, "strike_price", request.StrikePrice?.ToString());
        AddParameter(parameters, "sort", request.Sort);
        AddParameter(parameters, "order", request.Order);
        AddParameter(parameters, "limit", request.Limit?.ToString());
        AddParameter(parameters, "cursor", request.Cursor);

        return string.Join("&", parameters);
    }

    private static string BuildQueryString(TickerTypesRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "asset_class", request.AssetClass);
        AddParameter(parameters, "locale", request.Locale);

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

    /// <inheritdoc />
    public void Dispose()
    {
        if (_disposeClient)
        {
            _httpClient.Dispose();
        }
    }
}
