using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class OptionsContractsRequest
{
    /// <summary>
    /// Filters results by the options contract ticker.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; set; }

    /// <summary>
    /// Filters results by the underlying ticker.
    /// </summary>
    [JsonPropertyName("underlying_ticker")]
    public string? UnderlyingTicker { get; set; }

    /// <summary>
    /// Filters results by contract type (call or put).
    /// </summary>
    [JsonPropertyName("contract_type")]
    public string? ContractType { get; set; }

    /// <summary>
    /// Filters results by expiration date.
    /// </summary>
    [JsonPropertyName("expiration_date")]
    public DateOnly? ExpirationDate { get; set; }

    /// <summary>
    /// Filters results by strike price.
    /// </summary>
    [JsonPropertyName("strike_price")]
    public decimal? StrikePrice { get; set; }

    /// <summary>
    /// Sorts results by the specified field.
    /// </summary>
    [JsonPropertyName("sort")]
    public string? Sort { get; set; }

    /// <summary>
    /// Orders results ascending or descending.
    /// </summary>
    [JsonPropertyName("order")]
    public string? Order { get; set; }

    /// <summary>
    /// Limits the number of results returned.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// Continues pagination from the provided cursor.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }
}
