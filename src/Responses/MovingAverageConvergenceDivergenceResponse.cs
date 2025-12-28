using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class MovingAverageConvergenceDivergenceResponse
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
    /// The calculated MACD results.
    /// </summary>
    [JsonPropertyName("results")]
    public MovingAverageConvergenceDivergenceResults? Results { get; init; }

    /// <summary>
    /// Additional response fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class MovingAverageConvergenceDivergenceResults
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
    public IReadOnlyList<MovingAverageConvergenceDivergenceValue>? Values { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}

public sealed class MovingAverageConvergenceDivergenceValue
{
    /// <summary>
    /// The timestamp for the MACD value in milliseconds since epoch.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    /// <summary>
    /// The MACD value.
    /// </summary>
    [JsonPropertyName("value")]
    public decimal? Value { get; init; }

    /// <summary>
    /// The signal line value.
    /// </summary>
    [JsonPropertyName("signal")]
    public decimal? Signal { get; init; }

    /// <summary>
    /// The histogram value.
    /// </summary>
    [JsonPropertyName("histogram")]
    public decimal? Histogram { get; init; }

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
