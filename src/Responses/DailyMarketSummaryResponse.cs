using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class DailyMarketSummaryResponse
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
    /// The daily market summary results.
    /// </summary>
    [JsonPropertyName("results")]
    public IReadOnlyList<DailyMarketSummaryResult>? Results { get; init; }

    /// <summary>
    /// Additional response fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class DailyMarketSummaryResult
{
    /// <summary>
    /// The ticker symbol for the summary.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }

    /// <summary>
    /// The opening price for the session.
    /// </summary>
    [JsonPropertyName("o")]
    public decimal? Open { get; init; }

    /// <summary>
    /// The highest price for the session.
    /// </summary>
    [JsonPropertyName("h")]
    public decimal? High { get; init; }

    /// <summary>
    /// The lowest price for the session.
    /// </summary>
    [JsonPropertyName("l")]
    public decimal? Low { get; init; }

    /// <summary>
    /// The closing price for the session.
    /// </summary>
    [JsonPropertyName("c")]
    public decimal? Close { get; init; }

    /// <summary>
    /// The trading volume for the session.
    /// </summary>
    [JsonPropertyName("v")]
    public long? Volume { get; init; }

    /// <summary>
    /// The volume weighted average price for the session.
    /// </summary>
    [JsonPropertyName("vw")]
    public decimal? VolumeWeightedAveragePrice { get; init; }

    /// <summary>
    /// The number of transactions for the session.
    /// </summary>
    [JsonPropertyName("n")]
    public long? Transactions { get; init; }

    /// <summary>
    /// The timestamp for the session in milliseconds since epoch.
    /// </summary>
    [JsonPropertyName("t")]
    public long? Timestamp { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
