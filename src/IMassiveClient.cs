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

    /// <summary>
    /// Retrieves the exponential moving average indicator for a ticker.
    /// </summary>
    /// <param name="request">The request describing the indicator parameters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The exponential moving average response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<ExponentialMovingAverageResponse> GetExponentialMovingAverageAsync(
        ExponentialMovingAverageRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the moving average convergence/divergence indicator for a ticker.
    /// </summary>
    /// <param name="request">The request describing the indicator parameters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The MACD response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<MovingAverageConvergenceDivergenceResponse> GetMovingAverageConvergenceDivergenceAsync(
        MovingAverageConvergenceDivergenceRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the relative strength index indicator for a ticker.
    /// </summary>
    /// <param name="request">The request describing the indicator parameters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The RSI response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<RelativeStrengthIndexResponse> GetRelativeStrengthIndexAsync(
        RelativeStrengthIndexRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of exchanges.
    /// </summary>
    /// <param name="request">The request describing exchange filters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The exchanges response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<ExchangesResponse> GetExchangesAsync(
        ExchangesRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves market holidays.
    /// </summary>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The market holidays response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<List<MarketHolidayResult>> GetMarketHolidaysAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the current market status.
    /// </summary>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The market status response payload.</returns>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<MarketStatusResponse> GetMarketStatusAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves condition codes.
    /// </summary>
    /// <param name="request">The request describing condition code filters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The condition codes response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<ConditionCodesResponse> GetConditionCodesAsync(
        ConditionCodesRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves futures exchanges.
    /// </summary>
    /// <param name="request">The request describing futures exchange filters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The futures exchanges response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<FuturesExchangesResponse> GetFuturesExchangesAsync(
        FuturesExchangesRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves initial public offerings (IPOs).
    /// </summary>
    /// <param name="request">The request describing IPO filters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The IPO response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<InitialPublicOfferingsResponse> GetInitialPublicOfferingsAsync(
        InitialPublicOfferingsRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves historical stock split events.
    /// </summary>
    /// <param name="request">The request describing split filters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The splits response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<SplitsResponse> GetSplitsAsync(
        SplitsRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves historical cash dividend distributions.
    /// </summary>
    /// <param name="request">The request describing dividend filters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The dividends response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<DividendsResponse> GetDividendsAsync(
        DividendsRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves ticker events for a ticker, CUSIP, or Composite FIGI identifier.
    /// </summary>
    /// <param name="request">The request describing the identifier and filters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The ticker events response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<TickerEventsResponse> GetTickerEventsAsync(
        TickerEventsRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the options daily ticker summary (open/close) for a contract and date.
    /// </summary>
    /// <param name="request">The request describing the options ticker and date.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The options daily ticker summary response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<OptionsDailyTickerSummaryResponse> GetOptionsDailyTickerSummaryAsync(
        OptionsDailyTickerSummaryRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the previous day bar for an options contract.
    /// </summary>
    /// <param name="request">The request describing the options ticker and filters.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>The options previous day bar response payload.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
    /// <exception cref="MassiveApiException">
    /// Thrown when the Massive API request fails or the response cannot be deserialized.
    /// </exception>
    Task<OptionsPreviousDayBarResponse> GetOptionsPreviousDayBarAsync(
        OptionsPreviousDayBarRequest request,
        CancellationToken cancellationToken = default);
}
