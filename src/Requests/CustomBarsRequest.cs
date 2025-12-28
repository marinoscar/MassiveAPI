using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class CustomBarsRequest
{
    [JsonPropertyName("ticker")]
    public string? Ticker { get; set; }

    [JsonPropertyName("multiplier")]
    public int? Multiplier { get; set; }

    [JsonPropertyName("timespan")]
    public string? Timespan { get; set; }

    [JsonPropertyName("from")]
    public DateTimeOffset? From { get; set; }

    [JsonPropertyName("to")]
    public DateTimeOffset? To { get; set; }

    [JsonPropertyName("adjusted")]
    public bool? Adjusted { get; set; }

    [JsonPropertyName("sort")]
    public string? Sort { get; set; }

    [JsonPropertyName("limit")]
    public int? Limit { get; set; }
}
