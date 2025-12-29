using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class TickerEventsResponse
{
    /// <summary>
    /// A request id assigned by the server.
    /// </summary>
    [JsonPropertyName("request_id")]
    public string? RequestId { get; init; }

    /// <summary>
    /// Contains the requested event data for the specified ticker.
    /// </summary>
    [JsonPropertyName("results")]
    public TickerEventsResult? Results { get; init; }

    /// <summary>
    /// The status of this request's response.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// Additional response fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class TickerEventsResult
{
    /// <summary>
    /// An array of events containing the requested data.
    /// </summary>
    [JsonPropertyName("events")]
    public IReadOnlyList<TickerEvent>? Events { get; init; }

    /// <summary>
    /// The name of the asset.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}

public sealed class TickerEvent
{
    /// <summary>
    /// The event date.
    /// </summary>
    [JsonPropertyName("date")]
    public DateOnly? Date { get; init; }

    /// <summary>
    /// The event type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// The ticker change payload.
    /// </summary>
    [JsonPropertyName("ticker_change")]
    public TickerChange? TickerChange { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}

public sealed class TickerChange
{
    /// <summary>
    /// The ticker symbol after the change.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
