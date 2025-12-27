using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class OptionsContractOverviewResponse
{
    /// <summary>
    /// The status returned by the API.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// The unique identifier for the API request.
    /// </summary>
    [JsonPropertyName("request_id")]
    public string? RequestId { get; init; }

    /// <summary>
    /// The contract overview payload.
    /// </summary>
    [JsonPropertyName("data")]
    public OptionsContractOverviewData? Data { get; init; }

    /// <summary>
    /// Additional response fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class OptionsContractOverviewData
{
    /// <summary>
    /// The options contract ticker.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }

    /// <summary>
    /// The underlying asset ticker.
    /// </summary>
    [JsonPropertyName("underlying_ticker")]
    public string? UnderlyingTicker { get; init; }

    /// <summary>
    /// The contract type (call or put).
    /// </summary>
    [JsonPropertyName("contract_type")]
    public string? ContractType { get; init; }

    /// <summary>
    /// The contract expiration date.
    /// </summary>
    [JsonPropertyName("expiration_date")]
    public DateOnly? ExpirationDate { get; init; }

    /// <summary>
    /// The strike price for the contract.
    /// </summary>
    [JsonPropertyName("strike_price")]
    public decimal? StrikePrice { get; init; }

    /// <summary>
    /// The number of shares per contract.
    /// </summary>
    [JsonPropertyName("shares_per_contract")]
    public int? SharesPerContract { get; init; }

    /// <summary>
    /// The primary exchange for the contract.
    /// </summary>
    [JsonPropertyName("primary_exchange")]
    public string? PrimaryExchange { get; init; }

    /// <summary>
    /// The exercise style for the contract.
    /// </summary>
    [JsonPropertyName("exercise_style")]
    public string? ExerciseStyle { get; init; }

    /// <summary>
    /// The currency name for the contract.
    /// </summary>
    [JsonPropertyName("currency_name")]
    public string? CurrencyName { get; init; }

    /// <summary>
    /// The last updated timestamp for the contract data.
    /// </summary>
    [JsonPropertyName("last_updated_utc")]
    public DateTimeOffset? LastUpdatedUtc { get; init; }

    /// <summary>
    /// Additional contract fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
