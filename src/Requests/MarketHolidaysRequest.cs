using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class MarketHolidaysRequest
{
    /// <summary>
    /// Filters results by market (for example, stocks).
    /// </summary>
    [JsonPropertyName("market")]
    public string? Market { get; set; }

    /// <summary>
    /// Filters results by exchange code.
    /// </summary>
    [JsonPropertyName("exchange")]
    public string? Exchange { get; set; }

    /// <summary>
    /// Filters results by locale (for example, us).
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }
}
