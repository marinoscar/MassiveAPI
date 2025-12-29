using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class SplitsRequest
{
    /// <summary>
    /// Stock symbol for the company that executed the split.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; set; }

    /// <summary>
    /// Filter equal to any of the values (comma-separated list).
    /// </summary>
    [JsonPropertyName("ticker.any_of")]
    public string? TickerAnyOf { get; set; }

    /// <summary>
    /// Filter tickers greater than the value.
    /// </summary>
    [JsonPropertyName("ticker.gt")]
    public string? TickerGreaterThan { get; set; }

    /// <summary>
    /// Filter tickers greater than or equal to the value.
    /// </summary>
    [JsonPropertyName("ticker.gte")]
    public string? TickerGreaterThanOrEqual { get; set; }

    /// <summary>
    /// Filter tickers less than the value.
    /// </summary>
    [JsonPropertyName("ticker.lt")]
    public string? TickerLessThan { get; set; }

    /// <summary>
    /// Filter tickers less than or equal to the value.
    /// </summary>
    [JsonPropertyName("ticker.lte")]
    public string? TickerLessThanOrEqual { get; set; }

    /// <summary>
    /// Date when the stock split was applied.
    /// </summary>
    [JsonPropertyName("execution_date")]
    public DateOnly? ExecutionDate { get; set; }

    /// <summary>
    /// Filter execution_date greater than the value.
    /// </summary>
    [JsonPropertyName("execution_date.gt")]
    public DateOnly? ExecutionDateGreaterThan { get; set; }

    /// <summary>
    /// Filter execution_date greater than or equal to the value.
    /// </summary>
    [JsonPropertyName("execution_date.gte")]
    public DateOnly? ExecutionDateGreaterThanOrEqual { get; set; }

    /// <summary>
    /// Filter execution_date less than the value.
    /// </summary>
    [JsonPropertyName("execution_date.lt")]
    public DateOnly? ExecutionDateLessThan { get; set; }

    /// <summary>
    /// Filter execution_date less than or equal to the value.
    /// </summary>
    [JsonPropertyName("execution_date.lte")]
    public DateOnly? ExecutionDateLessThanOrEqual { get; set; }

    /// <summary>
    /// Classification of the share-change event.
    /// </summary>
    [JsonPropertyName("adjustment_type")]
    public string? AdjustmentType { get; set; }

    /// <summary>
    /// Filter adjustment_type equal to any of the values (comma-separated list).
    /// </summary>
    [JsonPropertyName("adjustment_type.any_of")]
    public string? AdjustmentTypeAnyOf { get; set; }

    /// <summary>
    /// Limit the maximum number of results returned.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// Sort columns and directions.
    /// </summary>
    [JsonPropertyName("sort")]
    public string? Sort { get; set; }
}
