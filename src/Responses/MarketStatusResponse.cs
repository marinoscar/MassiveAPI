using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class MarketStatusResponse
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
    /// The market status results.
    /// </summary>
    [JsonPropertyName("results")]
    public MarketStatusResult? Results { get; init; }

    /// <summary>
    /// Additional response fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class MarketStatusResult
{
    /// <summary>
    /// Indicates whether the market is currently open.
    /// </summary>
    [JsonPropertyName("market")]
    public string? Market { get; init; }

    /// <summary>
    /// The server time for the status response.
    /// </summary>
    [JsonPropertyName("server_time")]
    public DateTimeOffset? ServerTime { get; init; }

    /// <summary>
    /// The list of exchange statuses.
    /// </summary>
    [JsonPropertyName("exchanges")]
    public IReadOnlyList<MarketStatusExchange>? Exchanges { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}

public sealed class MarketStatusExchange
{
    /// <summary>
    /// The exchange identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// The exchange status.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
