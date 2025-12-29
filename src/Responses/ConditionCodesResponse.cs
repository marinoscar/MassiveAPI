using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class ConditionCodesResponse
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
    /// The condition code results.
    /// </summary>
    [JsonPropertyName("results")]
    public IReadOnlyList<ConditionCodeResult>? Results { get; init; }

    /// <summary>
    /// Additional response fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class ConditionCodeResult
{
    /// <summary>
    /// The condition code identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    /// <summary>
    /// The condition name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// The condition description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// The condition type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// The condition code.
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; init; }

    /// <summary>
    /// Additional fields not explicitly modeled.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
