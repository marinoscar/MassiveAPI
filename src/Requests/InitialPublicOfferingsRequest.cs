using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class InitialPublicOfferingsRequest
{
    /// <summary>
    /// Specify a case-sensitive ticker symbol.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; set; }

    /// <summary>
    /// Specify a us_code identifier.
    /// </summary>
    [JsonPropertyName("us_code")]
    public string? UsCode { get; set; }

    /// <summary>
    /// Specify an International Securities Identification Number (ISIN).
    /// </summary>
    [JsonPropertyName("isin")]
    public string? Isin { get; set; }

    /// <summary>
    /// Specify a listing date.
    /// </summary>
    [JsonPropertyName("listing_date")]
    public DateOnly? ListingDate { get; set; }

    /// <summary>
    /// Specify an IPO status.
    /// </summary>
    [JsonPropertyName("ipo_status")]
    public string? IpoStatus { get; set; }

    /// <summary>
    /// Filter listings where listing_date is greater than or equal to this date.
    /// </summary>
    [JsonPropertyName("listing_date.gte")]
    public DateOnly? ListingDateGreaterThanOrEqual { get; set; }

    /// <summary>
    /// Filter listings where listing_date is greater than this date.
    /// </summary>
    [JsonPropertyName("listing_date.gt")]
    public DateOnly? ListingDateGreaterThan { get; set; }

    /// <summary>
    /// Filter listings where listing_date is less than or equal to this date.
    /// </summary>
    [JsonPropertyName("listing_date.lte")]
    public DateOnly? ListingDateLessThanOrEqual { get; set; }

    /// <summary>
    /// Filter listings where listing_date is less than this date.
    /// </summary>
    [JsonPropertyName("listing_date.lt")]
    public DateOnly? ListingDateLessThan { get; set; }

    /// <summary>
    /// Order results based on the sort field.
    /// </summary>
    [JsonPropertyName("order")]
    public string? Order { get; set; }

    /// <summary>
    /// Limit the number of results returned.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// Sort field used for ordering.
    /// </summary>
    [JsonPropertyName("sort")]
    public string? Sort { get; set; }
}
