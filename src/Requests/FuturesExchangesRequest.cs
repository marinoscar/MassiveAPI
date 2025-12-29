using System.Text.Json.Serialization;

namespace MassiveAPI.Requests;

public sealed class FuturesExchangesRequest
{
    /// <summary>
    /// Limit the maximum number of results returned.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }
}
