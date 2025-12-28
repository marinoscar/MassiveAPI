using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class DailyTickerSummaryRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DailyTickerSummaryRequest"/> class.
    /// </summary>
    /// <param name="ticker">The ticker symbol to summarize.</param>
    /// <param name="date">The trading date for the summary.</param>
    public DailyTickerSummaryRequest(string ticker, DateOnly date)
    {
        if (string.IsNullOrWhiteSpace(ticker))
        {
            throw new ArgumentException("Ticker is required.", nameof(ticker));
        }

        Ticker = ticker;
        Date = date;
    }

    /// <summary>
    /// The ticker symbol to summarize.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string Ticker { get; }

    /// <summary>
    /// The trading date for the summary.
    /// </summary>
    [JsonPropertyName("date")]
    public DateOnly Date { get; }

    /// <summary>
    /// Indicates whether results are adjusted.
    /// </summary>
    [JsonPropertyName("adjusted")]
    public bool? Adjusted { get; set; }

    /// <summary>
    /// Filters results by locale (for example, us).
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }
}
