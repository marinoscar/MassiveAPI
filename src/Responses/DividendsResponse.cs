using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class DividendsResponse
{
    /// <summary>
    /// A request id assigned by the server.
    /// </summary>
    [JsonPropertyName("request_id")]
    public string? RequestId { get; init; }

    /// <summary>
    /// The results for this request.
    /// </summary>
    [JsonPropertyName("results")]
    public IReadOnlyList<DividendResult>? Results { get; init; }

    /// <summary>
    /// The status of this request's response.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// If present, this value can be used to fetch the next page.
    /// </summary>
    [JsonPropertyName("next_url")]
    public string? NextUrl { get; init; }

    /// <summary>
    /// Additional response fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class DividendResult
{
    /// <summary>
    /// Original dividend amount per share.
    /// </summary>
    [JsonPropertyName("cash_amount")]
    public decimal? CashAmount { get; init; }

    /// <summary>
    /// Currency code for the dividend payment.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; init; }

    /// <summary>
    /// Date when the company officially announced the dividend.
    /// </summary>
    [JsonPropertyName("declaration_date")]
    public DateOnly? DeclarationDate { get; init; }

    /// <summary>
    /// Classification describing the dividend recurrence pattern.
    /// </summary>
    [JsonPropertyName("distribution_type")]
    public string? DistributionType { get; init; }

    /// <summary>
    /// Date when the stock begins trading without the dividend value.
    /// </summary>
    [JsonPropertyName("ex_dividend_date")]
    public DateOnly? ExDividendDate { get; init; }

    /// <summary>
    /// How many times per year this dividend is expected to occur.
    /// </summary>
    [JsonPropertyName("frequency")]
    public int? Frequency { get; init; }

    /// <summary>
    /// Cumulative adjustment factor used to offset dividend effects on historical prices.
    /// </summary>
    [JsonPropertyName("historical_adjustment_factor")]
    public decimal? HistoricalAdjustmentFactor { get; init; }

    /// <summary>
    /// Unique identifier for each dividend record.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Date when the dividend payment is distributed.
    /// </summary>
    [JsonPropertyName("pay_date")]
    public DateOnly? PayDate { get; init; }

    /// <summary>
    /// Date when shareholders must be on record to be eligible.
    /// </summary>
    [JsonPropertyName("record_date")]
    public DateOnly? RecordDate { get; init; }

    /// <summary>
    /// Dividend amount adjusted for stock splits.
    /// </summary>
    [JsonPropertyName("split_adjusted_cash_amount")]
    public decimal? SplitAdjustedCashAmount { get; init; }

    /// <summary>
    /// Stock symbol for the company issuing the dividend.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
