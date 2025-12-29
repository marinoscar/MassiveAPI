using MassiveAPI.Builders;
using MassiveAPI.Requests;
using MassiveAPI.Responses;

namespace MassiveAPI;

public sealed partial class MassiveClient
{
    /// <inheritdoc />
    public async Task<SimpleMovingAverageResponse> GetSimpleMovingAverageAsync(
        SimpleMovingAverageRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? $"stocks/technical-indicators/sma/{Uri.EscapeDataString(request.Ticker)}"
            : $"stocks/technical-indicators/sma/{Uri.EscapeDataString(request.Ticker)}?{queryString}";

        return await _apiClient.SendAsync<SimpleMovingAverageResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve the simple moving average from the Massive API.",
                "Failed to deserialize the simple moving average response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<ExponentialMovingAverageResponse> GetExponentialMovingAverageAsync(
        ExponentialMovingAverageRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? $"stocks/technical-indicators/ema/{Uri.EscapeDataString(request.Ticker)}"
            : $"stocks/technical-indicators/ema/{Uri.EscapeDataString(request.Ticker)}?{queryString}";

        return await _apiClient.SendAsync<ExponentialMovingAverageResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve the exponential moving average from the Massive API.",
                "Failed to deserialize the exponential moving average response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<MovingAverageConvergenceDivergenceResponse> GetMovingAverageConvergenceDivergenceAsync(
        MovingAverageConvergenceDivergenceRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? $"stocks/technical-indicators/macd/{Uri.EscapeDataString(request.Ticker)}"
            : $"stocks/technical-indicators/macd/{Uri.EscapeDataString(request.Ticker)}?{queryString}";

        return await _apiClient.SendAsync<MovingAverageConvergenceDivergenceResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve the MACD from the Massive API.",
                "Failed to deserialize the MACD response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<RelativeStrengthIndexResponse> GetRelativeStrengthIndexAsync(
        RelativeStrengthIndexRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? $"stocks/technical-indicators/rsi/{Uri.EscapeDataString(request.Ticker)}"
            : $"stocks/technical-indicators/rsi/{Uri.EscapeDataString(request.Ticker)}?{queryString}";

        return await _apiClient.SendAsync<RelativeStrengthIndexResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve the RSI from the Massive API.",
                "Failed to deserialize the RSI response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }
}
