using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class OptionsPreviousDayBarResponse
{
    /// <summary>
    /// Indicates whether the results are adjusted.
    /// </summary>
    [JsonPropertyName("adjusted")]
    public bool? Adjusted { get; init; }

    /// <summary>
    /// The number of results returned for the query.
    /// </summary>
    [JsonPropertyName("queryCount")]
    public int? QueryCount { get; init; }

    /// <summary>
    /// A request id assigned by the server.
    /// </summary>
    [JsonPropertyName("request_id")]
    public string? RequestId { get; init; }

    /// <summary>
    /// The results for this request.
    /// </summary>
    [JsonPropertyName("results")]
    public IReadOnlyList<OptionsPreviousDayBarResult>? Results { get; init; }

    /// <summary>
    /// The number of results in the response.
    /// </summary>
    [JsonPropertyName("resultsCount")]
    public int? ResultsCount { get; init; }

    /// <summary>
    /// The response status.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// The requested ticker symbol.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }

    /// <summary>
    /// Additional response fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class OptionsPreviousDayBarResult
{
    /// <summary>
    /// The ticker symbol for the bar.
    /// </summary>
    [JsonPropertyName("T")]
    public string? Symbol { get; init; }

    /// <summary>
    /// The closing price for the session.
    /// </summary>
    [JsonPropertyName("c")]
    public decimal? Close { get; init; }

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
    /// The number of transactions.
    /// </summary>
    [JsonPropertyName("n")]
    public long? Transactions { get; init; }

    /// <summary>
    /// The opening price for the session.
    /// </summary>
    [JsonPropertyName("o")]
    public decimal? Open { get; init; }

    /// <summary>
    /// The timestamp for the session in milliseconds since epoch.
    /// </summary>
    [JsonPropertyName("t")]
    public long? Timestamp { get; init; }

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
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
