using System.Net.Http.Headers;
using MassiveAPI.Http;

namespace MassiveAPI;

/// <summary>
/// Provides a typed client for accessing the Massive API.
/// </summary>
public sealed partial class MassiveClient : IMassiveClient
{
    private readonly string _apiKey;
    private readonly HttpClient _httpClient;
    private readonly MassiveHttpClient _apiClient;
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
        _httpClient.BaseAddress = baseUri ?? new Uri("https://api.massive.com/");
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        _apiClient = new MassiveHttpClient(_httpClient, _apiKey);
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
