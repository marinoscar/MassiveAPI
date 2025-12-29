using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class ExchangesResponse
{
    /// <summary>
    /// The status returned by the API.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// The unique identifier for the API request.
    /// </summary>
    [JsonPropertyName("request_id")]
    public string? RequestId { get; init; }

    /// <summary>
    /// The exchange results.
    /// </summary>
    [JsonPropertyName("results")]
    public IReadOnlyList<ExchangeResult>? Results { get; init; }

    /// <summary>
    /// Additional response fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class ExchangeResult
{
    /// <summary>
    /// The exchange identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    /// <summary>
    /// The exchange type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// The exchange name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// The exchange market.
    /// </summary>
    [JsonPropertyName("market")]
    public string? Market { get; init; }

    /// <summary>
    /// The exchange locale.
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; init; }

    /// <summary>
    /// The MIC identifier for the exchange.
    /// </summary>
    [JsonPropertyName("mic")]
    public string? Mic { get; init; }

    /// <summary>
    /// The operating MIC identifier for the exchange.
    /// </summary>
    [JsonPropertyName("operating_mic")]
    public string? OperatingMic { get; init; }

    /// <summary>
    /// The participant MIC identifier for the exchange.
    /// </summary>
    [JsonPropertyName("participant_mic")]
    public string? ParticipantMic { get; init; }

    /// <summary>
    /// The exchange URL.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
