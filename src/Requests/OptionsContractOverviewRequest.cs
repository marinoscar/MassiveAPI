using System.Text.Json.Serialization;
using MassiveAPI.Helpers;

namespace MassiveAPI.Requests;

public sealed class OptionsContractOverviewRequest
{
    /// <summary>
    /// The options ticker composed from underlying, expiration, type, and strike.
    /// </summary>
    [JsonIgnore]
    public OptionsTicker? OptionsTicker { get; set; }

    /// <summary>
    /// The formatted options ticker value.
    /// </summary>
    [JsonPropertyName("options_ticker")]
    public string? OptionsTickerValue => OptionsTicker?.ToString();
}
