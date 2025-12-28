using MassiveAPI.Requests;
using MassiveAPI.Responses;

namespace MassiveAPI;

/// <summary>
/// Defines the Massive API client operations.
/// </summary>
public interface IMassiveClient : IDisposable
{
    /// <summary>
    /// Retrieves the overview data for a single ticker.
    /// </summary>
    /// <param name="request">The request describing the ticker to load.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The ticker overview response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<TickerOverviewResponse> GetTickerOverviewAsync(
        TickerOverviewRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves aggregated custom bar data for a ticker over a specified time range.
    /// </summary>
    /// <param name="request">The request describing the aggregation parameters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The custom bars response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="ArgumentException">
    /// Thrown when required request fields are missing or invalid.
    /// </exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<CustomBarsResponse> GetCustomBarsAsync(
        CustomBarsRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all tickers with optional filtering and pagination.
    /// </summary>
    /// <param name="request">The request describing ticker filters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The all tickers response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<AllTickersResponse> GetAllTickersAsync(
        AllTickersRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves aggregated custom bar data for an options ticker over a specified time range.
    /// </summary>
    /// <param name="request">The request describing the aggregation parameters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The options custom bars response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="ArgumentException">
    /// Thrown when required request fields are missing or invalid.
    /// </exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<OptionsCustomBarsResponse> GetOptionsCustomBarsAsync(
        OptionsCustomBarsRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the overview data for a single options contract.
    /// </summary>
    /// <param name="request">The request describing the options contract to load.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The options contract overview response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="request"/> is missing the options ticker.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<OptionsContractOverviewResponse> GetOptionsContractOverviewAsync(
        OptionsContractOverviewRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all options contracts with optional filtering and pagination.
    /// </summary>
    /// <param name="request">The request describing contract filters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The options contracts response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<OptionsContractsResponse> GetOptionsContractsAsync(
        OptionsContractsRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves available ticker types.
    /// </summary>
    /// <param name="request">The request describing ticker type filters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The ticker types response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<TickerTypesResponse> GetTickerTypesAsync(
        TickerTypesRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves related tickers for a specified ticker.
    /// </summary>
    /// <param name="request">The request describing the ticker to look up.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The related tickers response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<RelatedTickersResponse> GetRelatedTickersAsync(
        RelatedTickersRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the daily market summary for a given date.
    /// </summary>
    /// <param name="request">The request describing the summary date and filters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The daily market summary response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<DailyMarketSummaryResponse> GetDailyMarketSummaryAsync(
        DailyMarketSummaryRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the daily ticker summary for a given ticker and date.
    /// </summary>
    /// <param name="request">The request describing the ticker, date, and filters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The daily ticker summary response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<DailyTickerSummaryResponse> GetDailyTickerSummaryAsync(
        DailyTickerSummaryRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the previous day bar for a ticker.
    /// </summary>
    /// <param name="request">The request describing the ticker and filters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The previous day bar response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<PreviousDayBarResponse> GetPreviousDayBarAsync(
        PreviousDayBarRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the simple moving average indicator for a ticker.
    /// </summary>
    /// <param name="request">The request describing the indicator parameters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The simple moving average response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<SimpleMovingAverageResponse> GetSimpleMovingAverageAsync(
        SimpleMovingAverageRequest request,
        CancellationToken cancellationToken = default);
}
