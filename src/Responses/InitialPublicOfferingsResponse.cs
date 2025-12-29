using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class InitialPublicOfferingsResponse
{
    /// <summary>
    /// If present, this value can be used to fetch the next page of data.
    /// </summary>
    [JsonPropertyName("next_url")]
    public string? NextUrl { get; init; }

    /// <summary>
    /// A request id assigned by the server.
    /// </summary>
    [JsonPropertyName("request_id")]
    public string? RequestId { get; init; }

    /// <summary>
    /// An array of results containing the requested data.
    /// </summary>
    [JsonPropertyName("results")]
    public IReadOnlyList<InitialPublicOfferingResult>? Results { get; init; }

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

public sealed class InitialPublicOfferingResult
{
    /// <summary>
    /// The date when the IPO event was announced.
    /// </summary>
    [JsonPropertyName("announced_date")]
    public DateOnly? AnnouncedDate { get; init; }

    /// <summary>
    /// Underlying currency of the security.
    /// </summary>
    [JsonPropertyName("currency_code")]
    public string? CurrencyCode { get; init; }

    /// <summary>
    /// The price set by the company and its underwriters before the IPO goes live.
    /// </summary>
    [JsonPropertyName("final_issue_price")]
    public decimal? FinalIssuePrice { get; init; }

    /// <summary>
    /// The highest price within the IPO price range.
    /// </summary>
    [JsonPropertyName("highest_offer_price")]
    public decimal? HighestOfferPrice { get; init; }

    /// <summary>
    /// The status of the IPO event.
    /// </summary>
    [JsonPropertyName("ipo_status")]
    public string? IpoStatus { get; init; }

    /// <summary>
    /// International Securities Identification Number.
    /// </summary>
    [JsonPropertyName("isin")]
    public string? Isin { get; init; }

    /// <summary>
    /// The end date for the IPO issue window.
    /// </summary>
    [JsonPropertyName("issue_end_date")]
    public DateOnly? IssueEndDate { get; init; }

    /// <summary>
    /// The start date for the IPO issue window.
    /// </summary>
    [JsonPropertyName("issue_start_date")]
    public DateOnly? IssueStartDate { get; init; }

    /// <summary>
    /// Name of issuer.
    /// </summary>
    [JsonPropertyName("issuer_name")]
    public string? IssuerName { get; init; }

    /// <summary>
    /// The date when the IPO event was last modified.
    /// </summary>
    [JsonPropertyName("last_updated")]
    public DateOnly? LastUpdated { get; init; }

    /// <summary>
    /// First trading date for the newly listed entity.
    /// </summary>
    [JsonPropertyName("listing_date")]
    public DateOnly? ListingDate { get; init; }

    /// <summary>
    /// The minimum number of shares that can be bought or sold in a transaction.
    /// </summary>
    [JsonPropertyName("lot_size")]
    public long? LotSize { get; init; }

    /// <summary>
    /// The lowest price within the IPO price range.
    /// </summary>
    [JsonPropertyName("lowest_offer_price")]
    public decimal? LowestOfferPrice { get; init; }

    /// <summary>
    /// The upper limit of shares offered.
    /// </summary>
    [JsonPropertyName("max_shares_offered")]
    public long? MaxSharesOffered { get; init; }

    /// <summary>
    /// The lower limit of shares offered.
    /// </summary>
    [JsonPropertyName("min_shares_offered")]
    public long? MinSharesOffered { get; init; }

    /// <summary>
    /// Market Identifier Code (MIC) of the primary exchange.
    /// </summary>
    [JsonPropertyName("primary_exchange")]
    public string? PrimaryExchange { get; init; }

    /// <summary>
    /// Description of the security.
    /// </summary>
    [JsonPropertyName("security_description")]
    public string? SecurityDescription { get; init; }

    /// <summary>
    /// The classification of the stock.
    /// </summary>
    [JsonPropertyName("security_type")]
    public string? SecurityType { get; init; }

    /// <summary>
    /// The total number of shares outstanding.
    /// </summary>
    [JsonPropertyName("shares_outstanding")]
    public long? SharesOutstanding { get; init; }

    /// <summary>
    /// The ticker symbol of the IPO event.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }

    /// <summary>
    /// The total amount raised by the company for IPO.
    /// </summary>
    [JsonPropertyName("total_offer_size")]
    public decimal? TotalOfferSize { get; init; }

    /// <summary>
    /// The us_code identifier.
    /// </summary>
    [JsonPropertyName("us_code")]
    public string? UsCode { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
