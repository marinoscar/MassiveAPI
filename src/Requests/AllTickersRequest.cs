using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class AllTickersRequest
{
    /// <summary>
    /// Filters results to a specific ticker symbol.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; set; }

    /// <summary>
    /// Filters results by market (for example, stocks or otc).
    /// </summary>
    [JsonPropertyName("market")]
    public string? Market { get; set; }

    /// <summary>
    /// Filters results by locale (for example, us).
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    /// <summary>
    /// Filters results by asset type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Searches for tickers by name or symbol.
    /// </summary>
    [JsonPropertyName("search")]
    public string? Search { get; set; }

    /// <summary>
    /// Filters results by active status.
    /// </summary>
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

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
