using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class OptionsContractOverviewRequest
{
    public OptionsContractOverviewRequest(string optionsTickerValue)
    {
        if (string.IsNullOrWhiteSpace(optionsTickerValue))
        {
            throw new ArgumentException("Options ticker value is required.", nameof(optionsTickerValue));
        }

        OptionsTickerValue = optionsTickerValue;
    }

    [JsonPropertyName("options_ticker")]
    public string OptionsTickerValue { get; }
}
