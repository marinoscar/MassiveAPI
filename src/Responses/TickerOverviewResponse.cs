using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class TickerOverviewResponse
{
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("request_id")]
    public string? RequestId { get; init; }

    [JsonPropertyName("data")]
    public TickerOverviewData? Data { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class TickerOverviewData
{
    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("market")]
    public string? Market { get; init; }

    [JsonPropertyName("locale")]
    public string? Locale { get; init; }

    [JsonPropertyName("primary_exchange")]
    public string? PrimaryExchange { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("active")]
    public bool? Active { get; init; }

    [JsonPropertyName("currency_name")]
    public string? CurrencyName { get; init; }

    [JsonPropertyName("cik")]
    public string? Cik { get; init; }

    [JsonPropertyName("composite_figi")]
    public string? CompositeFigi { get; init; }

    [JsonPropertyName("share_class_figi")]
    public string? ShareClassFigi { get; init; }

    [JsonPropertyName("last_updated_utc")]
    public DateTimeOffset? LastUpdatedUtc { get; init; }

    [JsonPropertyName("market_cap")]
    public decimal? MarketCap { get; init; }

    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; init; }

    [JsonPropertyName("address")]
    public TickerOverviewAddress? Address { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("homepage_url")]
    public string? HomepageUrl { get; init; }

    [JsonPropertyName("total_employees")]
    public int? TotalEmployees { get; init; }

    [JsonPropertyName("list_date")]
    public DateOnly? ListDate { get; init; }

    [JsonPropertyName("branding")]
    public TickerOverviewBranding? Branding { get; init; }

    [JsonPropertyName("share_class_shares_outstanding")]
    public long? ShareClassSharesOutstanding { get; init; }

    [JsonPropertyName("weighted_shares_outstanding")]
    public long? WeightedSharesOutstanding { get; init; }

    [JsonPropertyName("round_lot")]
    public int? RoundLot { get; init; }

    [JsonPropertyName("ticker_root")]
    public string? TickerRoot { get; init; }

    [JsonPropertyName("ticker_suffix")]
    public string? TickerSuffix { get; init; }

    [JsonPropertyName("sic_code")]
    public string? SicCode { get; init; }

    [JsonPropertyName("sic_description")]
    public string? SicDescription { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}

public sealed class TickerOverviewAddress
{
    [JsonPropertyName("address1")]
    public string? Address1 { get; init; }

    [JsonPropertyName("address2")]
    public string? Address2 { get; init; }

    [JsonPropertyName("city")]
    public string? City { get; init; }

    [JsonPropertyName("state")]
    public string? State { get; init; }

    [JsonPropertyName("postal_code")]
    public string? PostalCode { get; init; }

    [JsonPropertyName("country")]
    public string? Country { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}

public sealed class TickerOverviewBranding
{
    [JsonPropertyName("logo_url")]
    public string? LogoUrl { get; init; }

    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
