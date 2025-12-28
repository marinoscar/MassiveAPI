using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class TickerTypesResponse
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
    /// The list of ticker types returned by the API.
    /// </summary>
    [JsonPropertyName("results")]
    public IReadOnlyList<TickerTypeResult>? Results { get; init; }

    /// <summary>
    /// Additional response fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class TickerTypeResult
{
    /// <summary>
    /// The ticker type code.
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; init; }

    /// <summary>
    /// The ticker type description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// The asset class for the ticker type.
    /// </summary>
    [JsonPropertyName("asset_class")]
    public string? AssetClass { get; init; }

    /// <summary>
    /// The locale for the ticker type.
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
