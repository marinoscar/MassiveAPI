using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class AllTickersResponse
{
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("request_id")]
    public string? RequestId { get; init; }

    [JsonPropertyName("next_url")]
    public string? NextUrl { get; init; }

    [JsonPropertyName("results")]
    public IReadOnlyList<TickerSummary>? Results { get; init; }

    [JsonPropertyName("count")]
    public int? Count { get; init; }

    [JsonPropertyName("results_count")]
    public int? ResultsCount { get; init; }

    [JsonPropertyName("query_count")]
    public int? QueryCount { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class TickerSummary
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

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
