using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class DailyMarketSummaryRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DailyMarketSummaryRequest"/> class.
    /// </summary>
    /// <param name="date">The trading date for the market summary.</param>
    public DailyMarketSummaryRequest(DateOnly date)
    {
        Date = date;
    }

    /// <summary>
    /// The trading date for the market summary.
    /// </summary>
    [JsonPropertyName("date")]
    public DateOnly Date { get; }

    /// <summary>
    /// Filters results by market (for example, stocks).
    /// </summary>
    [JsonPropertyName("market")]
    public string? Market { get; set; }

    /// <summary>
    /// Filters results by locale (for example, us).
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }
}
