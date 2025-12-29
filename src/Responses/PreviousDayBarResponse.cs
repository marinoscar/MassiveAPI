using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class PreviousDayBarResponse
{

    /// <summary>
    /// The ticker returned by the API.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }


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
    /// The previous day bar results.
    /// </summary>
    [JsonPropertyName("results")]
    public IReadOnlyList<PreviousDayBarResult>? Results { get; init; }

    /// <summary>
    /// The count of results returned.
    /// </summary>
    [JsonPropertyName("resultsCount")]
    public int? ResultsCount { get; init; }

    /// <summary>
    /// Additional response fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class PreviousDayBarResult
{
    /// <summary>
    /// The ticker symbol for the bar.
    /// </summary>
    [JsonPropertyName("T")]
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
    public decimal? Volume { get; init; }

    /// <summary>
    /// The volume weighted average price for the session.
    /// </summary>
    [JsonPropertyName("vw")]
    public decimal? VolumeWeightedAveragePrice { get; init; }

    /// <summary>
    /// The number of transactions for the session.
    /// </summary>
    [JsonPropertyName("n")]
    public decimal? Transactions { get; init; }

    /// <summary>
    /// The timestamp for the session in milliseconds since epoch.
    /// </summary>
    [JsonPropertyName("t")]
    public decimal? Timestamp { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
