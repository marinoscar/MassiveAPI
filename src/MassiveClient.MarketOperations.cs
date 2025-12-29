using MassiveAPI.Builders;
using MassiveAPI.Requests;
using MassiveAPI.Responses;

namespace MassiveAPI;

public sealed partial class MassiveClient
{
    /// <inheritdoc />
    public async Task<ExchangesResponse> GetExchangesAsync(
        ExchangesRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? "/v3/reference/exchanges"
            : $"/v3/reference/exchanges?{queryString}";

        return await _apiClient.SendAsync<ExchangesResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve exchanges from the Massive API.",
                "Failed to deserialize the exchanges response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<List<MarketHolidayResult>> GetMarketHolidaysAsync(
        CancellationToken cancellationToken = default)
    {
        var endpoint = "/v1/marketstatus/upcoming";

        return await _apiClient.SendAsync<List<MarketHolidayResult>>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve market holidays from the Massive API.",
                "Failed to deserialize the market holidays response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<MarketStatusResponse> GetMarketStatusAsync(CancellationToken cancellationToken = default)
    {
        return await _apiClient.SendAsync<MarketStatusResponse>(
                HttpMethod.Get,
                "/v1/marketstatus/now",
                content: null,
                "Failed to retrieve market status from the Massive API.",
                "Failed to deserialize the market status response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<ConditionCodesResponse> GetConditionCodesAsync(
        ConditionCodesRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? "/v3/reference/conditions"
            : $"/v3/reference/conditions?{queryString}";

        return await _apiClient.SendAsync<ConditionCodesResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve condition codes from the Massive API.",
                "Failed to deserialize the condition codes response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<FuturesExchangesResponse> GetFuturesExchangesAsync(
        FuturesExchangesRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? "futures/vX/exchanges"
            : $"futures/vX/exchanges?{queryString}";

        return await _apiClient.SendAsync<FuturesExchangesResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve futures exchanges from the Massive API.",
                "Failed to deserialize the futures exchanges response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }
}
