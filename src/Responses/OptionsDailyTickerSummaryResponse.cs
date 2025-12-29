using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class OptionsDailyTickerSummaryResponse
{
    /// <summary>
    /// The close price of the ticker symbol in after hours trading.
    /// </summary>
    [JsonPropertyName("afterHours")]
    public decimal? AfterHours { get; init; }

    /// <summary>
    /// The close price for the symbol in the given time period.
    /// </summary>
    [JsonPropertyName("close")]
    public decimal? Close { get; init; }

    /// <summary>
    /// The requested date.
    /// </summary>
    [JsonPropertyName("from")]
    public string? From { get; init; }

    /// <summary>
    /// The highest price for the symbol in the given time period.
    /// </summary>
    [JsonPropertyName("high")]
    public decimal? High { get; init; }

    /// <summary>
    /// The lowest price for the symbol in the given time period.
    /// </summary>
    [JsonPropertyName("low")]
    public decimal? Low { get; init; }

    /// <summary>
    /// The open price for the symbol in the given time period.
    /// </summary>
    [JsonPropertyName("open")]
    public decimal? Open { get; init; }

    /// <summary>
    /// The open price of the ticker symbol in pre-market trading.
    /// </summary>
    [JsonPropertyName("preMarket")]
    public decimal? PreMarket { get; init; }

    /// <summary>
    /// The status of this request's response.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// The exchange symbol that this item is traded under.
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; init; }

    /// <summary>
    /// The trading volume of the symbol in the given time period.
    /// </summary>
    [JsonPropertyName("volume")]
    public decimal? Volume { get; init; }

    /// <summary>
    /// Whether or not this aggregate is for an OTC ticker.
    /// </summary>
    [JsonPropertyName("otc")]
    public bool? Otc { get; init; }

    /// <summary>
    /// Additional response fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}
