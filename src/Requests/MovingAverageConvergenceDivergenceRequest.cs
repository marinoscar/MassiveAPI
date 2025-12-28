using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class MovingAverageConvergenceDivergenceRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MovingAverageConvergenceDivergenceRequest"/> class.
    /// </summary>
    /// <param name="ticker">The ticker symbol to calculate the indicator for.</param>
    public MovingAverageConvergenceDivergenceRequest(string ticker)
    {
        if (string.IsNullOrWhiteSpace(ticker))
        {
            throw new ArgumentException("Ticker is required.", nameof(ticker));
        }

        Ticker = ticker;
    }

    /// <summary>
    /// The ticker symbol to calculate the indicator for.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string Ticker { get; }

    /// <summary>
    /// The number of results to return.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The timestamp to start calculating from.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public DateTimeOffset? Timestamp { get; set; }

    /// <summary>
    /// The timestamp lower bound for the calculation.
    /// </summary>
    [JsonPropertyName("timestamp_lt")]
    public DateTimeOffset? TimestampLessThan { get; set; }

    /// <summary>
    /// The timestamp upper bound for the calculation.
    /// </summary>
    [JsonPropertyName("timestamp_gt")]
    public DateTimeOffset? TimestampGreaterThan { get; set; }

    /// <summary>
    /// The timespan to use for the calculation (for example, day).
    /// </summary>
    [JsonPropertyName("timespan")]
    public string? Timespan { get; set; }

    /// <summary>
    /// Indicates whether results are adjusted.
    /// </summary>
    [JsonPropertyName("adjusted")]
    public bool? Adjusted { get; set; }

    /// <summary>
    /// The short-term EMA window.
    /// </summary>
    [JsonPropertyName("short_window")]
    public int? ShortWindow { get; set; }

    /// <summary>
    /// The long-term EMA window.
    /// </summary>
    [JsonPropertyName("long_window")]
    public int? LongWindow { get; set; }

    /// <summary>
    /// The signal line window.
    /// </summary>
    [JsonPropertyName("signal_window")]
    public int? SignalWindow { get; set; }

    /// <summary>
    /// The sort order for results.
    /// </summary>
    [JsonPropertyName("sort")]
    public string? Sort { get; set; }

    /// <summary>
    /// The order direction for results.
    /// </summary>
    [JsonPropertyName("order")]
    public string? Order { get; set; }

    /// <summary>
    /// Indicates whether to expand the underlying aggregates.
    /// </summary>
    [JsonPropertyName("expand")]
    public bool? Expand { get; set; }
}
