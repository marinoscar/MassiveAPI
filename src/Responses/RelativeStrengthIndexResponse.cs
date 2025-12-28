using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class RelativeStrengthIndexResponse
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
    /// The calculated RSI results.
    /// </summary>
    [JsonPropertyName("results")]
    public RelativeStrengthIndexResults? Results { get; init; }

    /// <summary>
    /// Additional response fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class RelativeStrengthIndexResults
{
    /// <summary>
    /// The ticker symbol used for the calculation.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }

    /// <summary>
    /// The indicator values.
    /// </summary>
    [JsonPropertyName("values")]
    public IReadOnlyList<RelativeStrengthIndexValue>? Values { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}

public sealed class RelativeStrengthIndexValue
{
    /// <summary>
    /// The timestamp for the RSI value in milliseconds since epoch.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    /// <summary>
    /// The RSI value.
    /// </summary>
    [JsonPropertyName("value")]
    public decimal? Value { get; init; }

    /// <summary>
    /// The price of the underlying close at the timestamp.
    /// </summary>
    [JsonPropertyName("close")]
    public decimal? Close { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
