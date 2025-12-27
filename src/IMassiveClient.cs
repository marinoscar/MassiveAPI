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
}
