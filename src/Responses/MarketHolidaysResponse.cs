using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class MarketHolidaysResponse
{
    /// <summary>
    /// The status returned by the API.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// The unique identifier for the API request.
    /// </summary>
    [JsonPropertyName("request_id")]
    public string? RequestId { get; init; }

    /// <summary>
    /// The market holidays returned by the API.
    /// </summary>
    [JsonPropertyName("results")]
    public IReadOnlyList<MarketHolidayResult>? Results { get; init; }

    /// <summary>
    /// Additional response fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class MarketHolidayResult
{
    /// <summary>
    /// The holiday name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// The holiday date.
    /// </summary>
    [JsonPropertyName("date")]
    public DateOnly? Date { get; init; }

    /// <summary>
    /// The exchange for the holiday.
    /// </summary>
    [JsonPropertyName("exchange")]
    public string? Exchange { get; init; }

    /// <summary>
    /// The holiday status (for example, closed or early-close).
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// The open time for the holiday session.
    /// </summary>
    [JsonPropertyName("open")]
    public string? Open { get; init; }

    /// <summary>
    /// The close time for the holiday session.
    /// </summary>
    [JsonPropertyName("close")]
    public string? Close { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
