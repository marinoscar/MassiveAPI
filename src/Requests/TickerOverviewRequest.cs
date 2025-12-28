using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class TickerOverviewRequest
{
    public TickerOverviewRequest()
    {
    }

    public TickerOverviewRequest(string ticker)
    {
        if (string.IsNullOrWhiteSpace(ticker))
        {
            throw new ArgumentException("Ticker is required.", nameof(ticker));
        }

        Ticker = ticker;
    }

    [JsonPropertyName("ticker")]
    public string? Ticker { get; set; }
}
