using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class OptionsPreviousDayBarRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OptionsPreviousDayBarRequest"/> class.
    /// </summary>
    /// <param name="optionsTicker">The ticker symbol of the options contract.</param>
    public OptionsPreviousDayBarRequest(string optionsTicker)
    {
        if (string.IsNullOrWhiteSpace(optionsTicker))
        {
            throw new ArgumentException("Options ticker is required.", nameof(optionsTicker));
        }

        OptionsTicker = optionsTicker;
    }

    /// <summary>
    /// The ticker symbol of the options contract.
    /// </summary>
    [JsonPropertyName("optionsTicker")]
    public string OptionsTicker { get; }

    /// <summary>
    /// Whether or not the results are adjusted for splits.
    /// </summary>
    [JsonPropertyName("adjusted")]
    public bool? Adjusted { get; set; }
}
