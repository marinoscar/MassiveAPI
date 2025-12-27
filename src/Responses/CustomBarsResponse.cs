using System.Text.Json;
using System.Text.Json.Serialization;

namespace MassiveAPI.Responses;

public sealed class CustomBarsResponse
{
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("request_id")]
    public string? RequestId { get; init; }

    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }

    [JsonPropertyName("query_count")]
    public int? QueryCount { get; init; }

    [JsonPropertyName("results_count")]
    public int? ResultsCount { get; init; }

    [JsonPropertyName("adjusted")]
    public bool? Adjusted { get; init; }

    [JsonPropertyName("results")]
    public IReadOnlyList<CustomBarResult>? Results { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class CustomBarResult
{
    [JsonPropertyName("t")]
    public long? Timestamp { get; init; }

    [JsonPropertyName("o")]
    public decimal? Open { get; init; }

    [JsonPropertyName("h")]
    public decimal? High { get; init; }

    [JsonPropertyName("l")]
    public decimal? Low { get; init; }

    [JsonPropertyName("c")]
    public decimal? Close { get; init; }

    [JsonPropertyName("v")]
    public long? Volume { get; init; }

    [JsonPropertyName("vw")]
    public decimal? VolumeWeightedAveragePrice { get; init; }

    [JsonPropertyName("n")]
    public long? Transactions { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; init; }
}
