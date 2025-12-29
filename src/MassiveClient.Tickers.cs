using MassiveAPI.Builders;
using MassiveAPI.Requests;
using MassiveAPI.Responses;

namespace MassiveAPI;

public sealed partial class MassiveClient
{
    /// <inheritdoc />
    public async Task<TickerOverviewResponse> GetTickerOverviewAsync(
        TickerOverviewRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var endpoint = $"/v3/reference/tickers/{Uri.EscapeDataString(request.Ticker)}";
        return await _apiClient.SendAsync<TickerOverviewResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve the ticker overview from the Massive API.",
                "Failed to deserialize the ticker overview response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<AllTickersResponse> GetAllTickersAsync(
        AllTickersRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? "tickers"
            : $"tickers?{queryString}";

        return await _apiClient.SendAsync<AllTickersResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve tickers from the Massive API.",
                "Failed to deserialize the tickers response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<TickerTypesResponse> GetTickerTypesAsync(
        TickerTypesRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? "tickers/types"
            : $"tickers/types?{queryString}";

        return await _apiClient.SendAsync<TickerTypesResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve ticker types from the Massive API.",
                "Failed to deserialize the ticker types response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<RelatedTickersResponse> GetRelatedTickersAsync(
        RelatedTickersRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var endpoint = $"tickers/{Uri.EscapeDataString(request.Ticker)}/related";
        return await _apiClient.SendAsync<RelatedTickersResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve related tickers from the Massive API.",
                "Failed to deserialize the related tickers response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<TickerEventsResponse> GetTickerEventsAsync(
        TickerEventsRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? $"tickers/{Uri.EscapeDataString(request.Id)}/events"
            : $"tickers/{Uri.EscapeDataString(request.Id)}/events?{queryString}";

        return await _apiClient.SendAsync<TickerEventsResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve ticker events from the Massive API.",
                "Failed to deserialize the ticker events response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }
}
