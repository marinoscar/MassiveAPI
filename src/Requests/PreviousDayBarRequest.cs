using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class PreviousDayBarRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PreviousDayBarRequest"/> class.
    /// </summary>
    /// <param name="ticker">The ticker symbol to fetch the previous day bar for.</param>
    public PreviousDayBarRequest(string ticker)
    {
        if (string.IsNullOrWhiteSpace(ticker))
        {
            throw new ArgumentException("Ticker is required.", nameof(ticker));
        }

        Ticker = ticker;
    }

    /// <summary>
    /// The ticker symbol to fetch the previous day bar for.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string Ticker { get; }

    /// <summary>
    /// Indicates whether results are adjusted.
    /// </summary>
    [JsonPropertyName("adjusted")]
    public bool? Adjusted { get; set; }
}
