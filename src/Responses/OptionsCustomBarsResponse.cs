using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class OptionsCustomBarsResponse
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
    /// The options ticker symbol for the response payload.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }

    /// <summary>
    /// The number of results returned for the query.
    /// </summary>
    [JsonPropertyName("query_count")]
    public int? QueryCount { get; init; }

    /// <summary>
    /// The number of results included in the response.
    /// </summary>
    [JsonPropertyName("results_count")]
    public int? ResultsCount { get; init; }

    /// <summary>
    /// Indicates whether the results are adjusted.
    /// </summary>
    [JsonPropertyName("adjusted")]
    public bool? Adjusted { get; init; }

    /// <summary>
    /// The aggregated bar results.
    /// </summary>
    [JsonPropertyName("results")]
    public IReadOnlyList<OptionsCustomBarResult>? Results { get; init; }

    /// <summary>
    /// Additional response fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class OptionsCustomBarResult
{
    /// <summary>
    /// The bar timestamp in milliseconds since epoch.
    /// </summary>
    [JsonPropertyName("t")]
    public long? Timestamp { get; init; }

    /// <summary>
    /// The opening price for the bar.
    /// </summary>
    [JsonPropertyName("o")]
    public decimal? Open { get; init; }

    /// <summary>
    /// The highest price for the bar.
    /// </summary>
    [JsonPropertyName("h")]
    public decimal? High { get; init; }

    /// <summary>
    /// The lowest price for the bar.
    /// </summary>
    [JsonPropertyName("l")]
    public decimal? Low { get; init; }

    /// <summary>
    /// The closing price for the bar.
    /// </summary>
    [JsonPropertyName("c")]
    public decimal? Close { get; init; }

    /// <summary>
    /// The trading volume for the bar.
    /// </summary>
    [JsonPropertyName("v")]
    public long? Volume { get; init; }

    /// <summary>
    /// The volume weighted average price for the bar.
    /// </summary>
    [JsonPropertyName("vw")]
    public decimal? VolumeWeightedAveragePrice { get; init; }

    /// <summary>
    /// The number of transactions in the bar.
    /// </summary>
    [JsonPropertyName("n")]
    public long? Transactions { get; init; }

    /// <summary>
    /// Additional bar fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
