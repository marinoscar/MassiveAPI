using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class SplitsResponse
{
    /// <summary>
    /// A request id assigned by the server.
    /// </summary>
    [JsonPropertyName("request_id")]
    public string? RequestId { get; init; }

    /// <summary>
    /// The results for this request.
    /// </summary>
    [JsonPropertyName("results")]
    public IReadOnlyList<SplitResult>? Results { get; init; }

    /// <summary>
    /// The status of this request's response.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// If present, this value can be used to fetch the next page.
    /// </summary>
    [JsonPropertyName("next_url")]
    public string? NextUrl { get; init; }

    /// <summary>
    /// Additional response fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class SplitResult
{
    /// <summary>
    /// Classification of the share-change event.
    /// </summary>
    [JsonPropertyName("adjustment_type")]
    public string? AdjustmentType { get; init; }

    /// <summary>
    /// Date when the stock split was applied.
    /// </summary>
    [JsonPropertyName("execution_date")]
    public DateOnly? ExecutionDate { get; init; }

    /// <summary>
    /// Cumulative adjustment factor for historical prices.
    /// </summary>
    [JsonPropertyName("historical_adjustment_factor")]
    public decimal? HistoricalAdjustmentFactor { get; init; }

    /// <summary>
    /// Unique identifier for the split event.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Denominator of the split ratio.
    /// </summary>
    [JsonPropertyName("split_from")]
    public decimal? SplitFrom { get; init; }

    /// <summary>
    /// Numerator of the split ratio.
    /// </summary>
    [JsonPropertyName("split_to")]
    public decimal? SplitTo { get; init; }

    /// <summary>
    /// Stock symbol for the company that executed the split.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
