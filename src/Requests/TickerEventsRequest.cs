using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class TickerEventsRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TickerEventsRequest"/> class.
    /// </summary>
    /// <param name="id">Identifier of an asset (ticker, CUSIP, or Composite FIGI).</param>
    public TickerEventsRequest(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Identifier is required.", nameof(id));
        }

        Id = id;
    }

    /// <summary>
    /// Identifier of an asset (ticker, CUSIP, or Composite FIGI).
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; }

    /// <summary>
    /// A comma-separated list of event types to include.
    /// </summary>
    [JsonPropertyName("types")]
    public string? Types { get; set; }
}
