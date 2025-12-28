using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class OptionsCustomBarsRequest
{
    /// <summary>
    /// The options ticker symbol to aggregate.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; set; }

    /// <summary>
    /// The size of the time window to aggregate.
    /// </summary>
    [JsonPropertyName("multiplier")]
    public int? Multiplier { get; set; }

    /// <summary>
    /// The unit of time for the aggregation window.
    /// </summary>
    [JsonPropertyName("timespan")]
    public string? Timespan { get; set; }

    /// <summary>
    /// The start of the aggregation range.
    /// </summary>
    [JsonPropertyName("from")]
    public DateTimeOffset? From { get; set; }

    /// <summary>
    /// The end of the aggregation range.
    /// </summary>
    [JsonPropertyName("to")]
    public DateTimeOffset? To { get; set; }

    /// <summary>
    /// Indicates whether the results are adjusted.
    /// </summary>
    [JsonPropertyName("adjusted")]
    public bool? Adjusted { get; set; }

    /// <summary>
    /// The sort order for results.
    /// </summary>
    [JsonPropertyName("sort")]
    public string? Sort { get; set; }

    /// <summary>
    /// The maximum number of results to return.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }
}
