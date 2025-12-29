using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Http;

internal sealed class MassiveHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public MassiveHttpClient(HttpClient httpClient, string apiKey)
    {
        _httpClient = httpClient;
        _apiKey = apiKey;
    }

    public async Task<TResponse> SendAsync<TResponse>(
        HttpMethod method,
        string endpoint,
        HttpContent? content,
        string requestErrorMessage,
        string deserializationErrorMessage,
        CancellationToken cancellationToken = default,
        JsonSerializerOptions jsonSerializerOptions = default!)
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

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                var notAuthorized = await TryParseNotAuthorizedAsync(response, cancellationToken).ConfigureAwait(false);
                if (notAuthorized is not null)
                {
                    throw new MassiveNotAuthorizedException(notAuthorized.Message, notAuthorized.RequestId);
                }
            }

            response.EnsureSuccessStatusCode();

            await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);

            var options = jsonSerializerOptions ?? SerializerOptions;

            var payload = await JsonSerializer.DeserializeAsync<TResponse>(stream, options, cancellationToken)
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

    private static async Task<NotAuthorizedError?> TryParseNotAuthorizedAsync(
        HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        try
        {
            await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
            var payload = await JsonSerializer.DeserializeAsync<NotAuthorizedError>(stream, SerializerOptions, cancellationToken)
                .ConfigureAwait(false);
            if (payload is null)
            {
                return null;
            }

            return string.Equals(payload.Status, "NOT_AUTHORIZED", StringComparison.OrdinalIgnoreCase)
                ? payload
                : null;
        }
        catch (JsonException)
        {
            return null;
        }
    }

    private sealed class NotAuthorizedError
    {
        [JsonPropertyName("status")]
        public string? Status { get; init; }

        [JsonPropertyName("request_id")]
        public string? RequestId { get; init; }

        [JsonPropertyName("message")]
        public string Message { get; init; } = "You are not authorized to access this data.";
    }

    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
}
