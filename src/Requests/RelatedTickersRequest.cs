using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class RelatedTickersRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RelatedTickersRequest"/> class.
    /// </summary>
    /// <param name="ticker">The ticker symbol to look up related tickers for.</param>
    public RelatedTickersRequest(string ticker)
    {
        if (string.IsNullOrWhiteSpace(ticker))
        {
            throw new ArgumentException("Ticker is required.", nameof(ticker));
        }

        Ticker = ticker;
    }

    /// <summary>
    /// The ticker symbol to look up related tickers for.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string Ticker { get; }
}
