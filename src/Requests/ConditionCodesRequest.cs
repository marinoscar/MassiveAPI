using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class ConditionCodesRequest
{
    /// <summary>
    /// Filters results by asset class (for example, stocks).
    /// </summary>
    [JsonPropertyName("asset_class")]
    public string? AssetClass { get; set; }

    /// <summary>
    /// Filters results by locale (for example, us).
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }
}
