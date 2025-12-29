using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class OptionsDailyTickerSummaryRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OptionsDailyTickerSummaryRequest"/> class.
    /// </summary>
    /// <param name="optionsTicker">The ticker symbol of the options contract.</param>
    /// <param name="date">The date of the requested open/close in YYYY-MM-DD format.</param>
    public OptionsDailyTickerSummaryRequest(string optionsTicker, DateOnly date)
    {
        if (string.IsNullOrWhiteSpace(optionsTicker))
        {
            throw new ArgumentException("Options ticker is required.", nameof(optionsTicker));
        }

        OptionsTicker = optionsTicker;
        Date = date;
    }

    /// <summary>
    /// The ticker symbol of the options contract.
    /// </summary>
    [JsonPropertyName("optionsTicker")]
    public string OptionsTicker { get; }

    /// <summary>
    /// The date of the requested open/close.
    /// </summary>
    [JsonPropertyName("date")]
    public DateOnly Date { get; }

    /// <summary>
    /// Whether or not the results are adjusted for splits.
    /// </summary>
    [JsonPropertyName("adjusted")]
    public bool? Adjusted { get; set; }
}
