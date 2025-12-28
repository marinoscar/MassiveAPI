using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class RelatedTickersResponse
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
    /// The related ticker results.
    /// </summary>
    [JsonPropertyName("results")]
    public IReadOnlyList<RelatedTickerResult>? Results { get; init; }

    /// <summary>
    /// Additional response fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class RelatedTickerResult
{
    /// <summary>
    /// The related ticker symbol.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }

    /// <summary>
    /// The ticker name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// The market for the ticker.
    /// </summary>
    [JsonPropertyName("market")]
    public string? Market { get; init; }

    /// <summary>
    /// The locale for the ticker.
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; init; }

    /// <summary>
    /// The primary exchange for the ticker.
    /// </summary>
    [JsonPropertyName("primary_exchange")]
    public string? PrimaryExchange { get; init; }

    /// <summary>
    /// The ticker type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Indicates whether the ticker is active.
    /// </summary>
    [JsonPropertyName("active")]
    public bool? Active { get; init; }

    /// <summary>
    /// The CIK identifier for the ticker.
    /// </summary>
    [JsonPropertyName("cik")]
    public string? Cik { get; init; }

    /// <summary>
    /// The composite FIGI identifier.
    /// </summary>
    [JsonPropertyName("composite_figi")]
    public string? CompositeFigi { get; init; }

    /// <summary>
    /// The share class FIGI identifier.
    /// </summary>
    [JsonPropertyName("share_class_figi")]
    public string? ShareClassFigi { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
