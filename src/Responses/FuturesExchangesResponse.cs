using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class FuturesExchangesResponse
{
    /// <summary>
    /// The total number of results returned.
    /// </summary>
    [JsonPropertyName("count")]
    public int? Count { get; init; }

    /// <summary>
    /// A request id assigned by the server.
    /// </summary>
    [JsonPropertyName("request_id")]
    public string? RequestId { get; init; }

    /// <summary>
    /// The results for this request.
    /// </summary>
    [JsonPropertyName("results")]
    public IReadOnlyList<FuturesExchangeResult>? Results { get; init; }

    /// <summary>
    /// The response status.
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

public sealed class FuturesExchangeResult
{
    /// <summary>
    /// Well-known acronym for the exchange.
    /// </summary>
    [JsonPropertyName("acronym")]
    public string? Acronym { get; init; }

    /// <summary>
    /// Numeric identifier for the futures exchange.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Geographic location code where the exchange operates.
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; init; }

    /// <summary>
    /// Market Identifier Code (MIC).
    /// </summary>
    [JsonPropertyName("mic")]
    public string? Mic { get; init; }

    /// <summary>
    /// Full official name of the futures exchange.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Operating Market Identifier Code for the exchange.
    /// </summary>
    [JsonPropertyName("operating_mic")]
    public string? OperatingMic { get; init; }

    /// <summary>
    /// Type of venue for the exchange.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Official website URL of the exchange organization.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
