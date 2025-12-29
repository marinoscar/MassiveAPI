using System.Text;
using System.Text.Json;
using MassiveAPI.Builders;
using MassiveAPI.Requests;
using MassiveAPI.Responses;

namespace MassiveAPI;

public sealed partial class MassiveClient
{
    /// <inheritdoc />
    public async Task<CustomBarsResponse> GetCustomBarsAsync(
        CustomBarsRequest request,
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

        var endpoint = "stocks/aggregates/custom-bars";
        var payload = JsonSerializer.Serialize(request);
        var content = new StringContent(payload, Encoding.UTF8, "application/json");
        return await _apiClient.SendAsync<CustomBarsResponse>(
                HttpMethod.Post,
                endpoint,
                content,
                "Failed to retrieve custom bars from the Massive API.",
                "Failed to deserialize the custom bars response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<DailyMarketSummaryResponse> GetDailyMarketSummaryAsync(
        DailyMarketSummaryRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? "stocks/aggregates/daily-market-summary"
            : $"stocks/aggregates/daily-market-summary?{queryString}";

        return await _apiClient.SendAsync<DailyMarketSummaryResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve the daily market summary from the Massive API.",
                "Failed to deserialize the daily market summary response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<DailyTickerSummaryResponse> GetDailyTickerSummaryAsync(
        DailyTickerSummaryRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? $"stocks/aggregates/daily-ticker-summary/{Uri.EscapeDataString(request.Ticker)}/{request.Date:yyyy-MM-dd}"
            : $"stocks/aggregates/daily-ticker-summary/{Uri.EscapeDataString(request.Ticker)}/{request.Date:yyyy-MM-dd}?{queryString}";

        return await _apiClient.SendAsync<DailyTickerSummaryResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve the daily ticker summary from the Massive API.",
                "Failed to deserialize the daily ticker summary response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<PreviousDayBarResponse> GetPreviousDayBarAsync(
        PreviousDayBarRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var queryString = QueryStringBuilder.Build(request);
        var endpoint = string.IsNullOrWhiteSpace(queryString)
            ? $"stocks/aggregates/previous-day-bar/{Uri.EscapeDataString(request.Ticker)}"
            : $"stocks/aggregates/previous-day-bar/{Uri.EscapeDataString(request.Ticker)}?{queryString}";

        return await _apiClient.SendAsync<PreviousDayBarResponse>(
                HttpMethod.Get,
                endpoint,
                content: null,
                "Failed to retrieve the previous day bar from the Massive API.",
                "Failed to deserialize the previous day bar response from the Massive API.",
                cancellationToken)
            .ConfigureAwait(false);
    }
}
