using MassiveAPI.Builders;
using MassiveAPI.Requests;
using MassiveAPI.Responses;
using System.Text.Json;

namespace MassiveAPI;

public sealed partial class MassiveClient
{
    /// <inheritdoc />
    public async Task<OptionsCustomBarsResponse> GetOptionsCustomBarsAsync(
        OptionsCustomBarsRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (string.IsNullOrWhiteSpace(request.Ticker))
        {
            throw new ArgumentException("Ticker is required.", nameof(request));
        }

        if (request.Multiplier is null || request.Multiplier <= 0)
        {
            throw new ArgumentException("Multiplier must be greater than zero.", nameof(request));
        }

        if (string.IsNullOrWhiteSpace(request.Timespan))
        {
            throw new ArgumentException("Timespan is required.", nameof(request));
        }

        if (request.From is null || request.To is null)
        {
            throw new ArgumentException("Both from and to timestamps are required.", nameof(request));
        }

        var from = request.From.Value.ToString("yyyy-MM-dd");
        var to = request.To.Value.ToString("yyyy-MM-dd");
        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? $"/v2/aggs/ticker/{Uri.EscapeDataString(request.Ticker)}/range/{request.Multiplier}/{request.Timespan}/{from}/{to}"
            : $"/v2/aggs/ticker/{Uri.EscapeDataString(request.Ticker)}/range/{request.Multiplier}/{request.Timespan}/{from}/{to}?{queryString}";
        return await _apiClient.SendAsync<OptionsCustomBarsResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve options custom bars from the Massive API.",
                "Failed to deserialize the options custom bars response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<OptionsContractOverviewResponse> GetOptionsContractOverviewAsync(
        OptionsContractOverviewRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var optionsTicker = request.OptionsTickerValue;
        if (string.IsNullOrWhiteSpace(optionsTicker))
        {
            throw new ArgumentException("Options ticker is required.", nameof(request));
        }

        var endpoint = $"/v3/reference/options/contracts/{Uri.EscapeDataString(optionsTicker)}";
        return await _apiClient.SendAsync<OptionsContractOverviewResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve the options contract overview from the Massive API.",
                "Failed to deserialize the options contract overview response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<OptionsContractsResponse> GetOptionsContractsAsync(
        OptionsContractsRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? "/v3/reference/options/contracts"
            : $"/v3/reference/options/contracts?{queryString}";

        return await _apiClient.SendAsync<OptionsContractsResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve options contracts from the Massive API.",
                "Failed to deserialize the options contracts response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<OptionsDailyTickerSummaryResponse> GetOptionsDailyTickerSummaryAsync(
        OptionsDailyTickerSummaryRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? $"/v1/open-close/{Uri.EscapeDataString(request.OptionsTicker)}/{request.Date:yyyy-MM-dd}"
            : $"/v1/open-close/{Uri.EscapeDataString(request.OptionsTicker)}/{request.Date:yyyy-MM-dd}?{queryString}";

        return await _apiClient.SendAsync<OptionsDailyTickerSummaryResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve the options daily ticker summary from the Massive API.",
                "Failed to deserialize the options daily ticker summary response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<OptionsPreviousDayBarResponse> GetOptionsPreviousDayBarAsync(
        OptionsPreviousDayBarRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? $"/v2/aggs/ticker/{Uri.EscapeDataString(request.OptionsTicker)}/prev"
            : $"/v2/aggs/ticker/{Uri.EscapeDataString(request.OptionsTicker)}/prev?{queryString}";

        return await _apiClient.SendAsync<OptionsPreviousDayBarResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve the options previous day bar from the Massive API.",
                "Failed to deserialize the options previous day bar response from the Massive API.",
                cancellationToken, new JsonSerializerOptions() { 
                    PropertyNameCaseInsensitive = false
                })
            .ConfigureAwait(false);
    }
}
