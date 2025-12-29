using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class DividendsRequest
{
    /// <summary>
    /// Stock symbol for the company issuing the dividend.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; set; }

    /// <summary>
    /// Filter equal to any of the values (comma-separated list).
    /// </summary>
    [JsonPropertyName("ticker.any_of")]
    public string? TickerAnyOf { get; set; }

    /// <summary>
    /// Filter tickers greater than the value.
    /// </summary>
    [JsonPropertyName("ticker.gt")]
    public string? TickerGreaterThan { get; set; }

    /// <summary>
    /// Filter tickers greater than or equal to the value.
    /// </summary>
    [JsonPropertyName("ticker.gte")]
    public string? TickerGreaterThanOrEqual { get; set; }

    /// <summary>
    /// Filter tickers less than the value.
    /// </summary>
    [JsonPropertyName("ticker.lt")]
    public string? TickerLessThan { get; set; }

    /// <summary>
    /// Filter tickers less than or equal to the value.
    /// </summary>
    [JsonPropertyName("ticker.lte")]
    public string? TickerLessThanOrEqual { get; set; }

    /// <summary>
    /// Date when the stock begins trading without the dividend value.
    /// </summary>
    [JsonPropertyName("ex_dividend_date")]
    public DateOnly? ExDividendDate { get; set; }

    /// <summary>
    /// Filter ex_dividend_date greater than the value.
    /// </summary>
    [JsonPropertyName("ex_dividend_date.gt")]
    public DateOnly? ExDividendDateGreaterThan { get; set; }

    /// <summary>
    /// Filter ex_dividend_date greater than or equal to the value.
    /// </summary>
    [JsonPropertyName("ex_dividend_date.gte")]
    public DateOnly? ExDividendDateGreaterThanOrEqual { get; set; }

    /// <summary>
    /// Filter ex_dividend_date less than the value.
    /// </summary>
    [JsonPropertyName("ex_dividend_date.lt")]
    public DateOnly? ExDividendDateLessThan { get; set; }

    /// <summary>
    /// Filter ex_dividend_date less than or equal to the value.
    /// </summary>
    [JsonPropertyName("ex_dividend_date.lte")]
    public DateOnly? ExDividendDateLessThanOrEqual { get; set; }

    /// <summary>
    /// How many times per year this dividend is expected to occur.
    /// </summary>
    [JsonPropertyName("frequency")]
    public int? Frequency { get; set; }

    /// <summary>
    /// Filter frequency greater than the value.
    /// </summary>
    [JsonPropertyName("frequency.gt")]
    public int? FrequencyGreaterThan { get; set; }

    /// <summary>
    /// Filter frequency greater than or equal to the value.
    /// </summary>
    [JsonPropertyName("frequency.gte")]
    public int? FrequencyGreaterThanOrEqual { get; set; }

    /// <summary>
    /// Filter frequency less than the value.
    /// </summary>
    [JsonPropertyName("frequency.lt")]
    public int? FrequencyLessThan { get; set; }

    /// <summary>
    /// Filter frequency less than or equal to the value.
    /// </summary>
    [JsonPropertyName("frequency.lte")]
    public int? FrequencyLessThanOrEqual { get; set; }

    /// <summary>
    /// Classification describing the dividend recurrence pattern.
    /// </summary>
    [JsonPropertyName("distribution_type")]
    public string? DistributionType { get; set; }

    /// <summary>
    /// Filter distribution_type equal to any of the values (comma-separated list).
    /// </summary>
    [JsonPropertyName("distribution_type.any_of")]
    public string? DistributionTypeAnyOf { get; set; }

    /// <summary>
    /// Limit the maximum number of results returned.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// Sort columns and directions.
    /// </summary>
    [JsonPropertyName("sort")]
    public string? Sort { get; set; }
}
