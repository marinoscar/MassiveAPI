using MassiveAPI.Builders;
using MassiveAPI.Requests;
using MassiveAPI.Responses;

namespace MassiveAPI;

public sealed partial class MassiveClient
{
    /// <inheritdoc />
    public async Task<InitialPublicOfferingsResponse> GetInitialPublicOfferingsAsync(
        InitialPublicOfferingsRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? "vX/reference/ipos"
            : $"vX/reference/ipos?{queryString}";

        return await _apiClient.SendAsync<InitialPublicOfferingsResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve IPOs from the Massive API.",
                "Failed to deserialize the IPOs response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<SplitsResponse> GetSplitsAsync(
        SplitsRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? "stocks/v1/splits"
            : $"stocks/v1/splits?{queryString}";

        return await _apiClient.SendAsync<SplitsResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve splits from the Massive API.",
                "Failed to deserialize the splits response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<DividendsResponse> GetDividendsAsync(
        DividendsRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? "stocks/v1/dividends"
            : $"stocks/v1/dividends?{queryString}";

        return await _apiClient.SendAsync<DividendsResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve dividends from the Massive API.",
                "Failed to deserialize the dividends response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }
}
