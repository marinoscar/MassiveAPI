using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class OptionsContractsResponse
{
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("request_id")]
    public string? RequestId { get; init; }

    [JsonPropertyName("next_url")]
    public string? NextUrl { get; init; }

    [JsonPropertyName("results")]
    public IReadOnlyList<OptionsContractSummary>? Results { get; init; }

    [JsonPropertyName("count")]
    public int? Count { get; init; }

    [JsonPropertyName("results_count")]
    public int? ResultsCount { get; init; }

    [JsonPropertyName("query_count")]
    public int? QueryCount { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class OptionsContractSummary
{
    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }

    [JsonPropertyName("underlying_ticker")]
    public string? UnderlyingTicker { get; init; }

    [JsonPropertyName("contract_type")]
    public string? ContractType { get; init; }

    [JsonPropertyName("exercise_style")]
    public string? ExerciseStyle { get; init; }

    [JsonPropertyName("expiration_date")]
    public DateOnly? ExpirationDate { get; init; }

    [JsonPropertyName("shares_per_contract")]
    public int? SharesPerContract { get; init; }

    [JsonPropertyName("strike_price")]
    public decimal? StrikePrice { get; init; }

    [JsonPropertyName("primary_exchange")]
    public string? PrimaryExchange { get; init; }

    [JsonPropertyName("cfi")]
    public string? Cfi { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
