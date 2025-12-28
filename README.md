# MassiveAPI

A typed C# client library for the Massive REST API. The library provides request/response models
and a `MassiveClient` implementation (plus `IMassiveClient`) for interacting with the Massive
endpoints using strongly-typed inputs and outputs.

**Keywords:** Massive API, Massive REST API, stocks, options, tickers, aggregates, C# SDK, .NET client.

## Features

- Typed request/response models organized under `MassiveAPI.Requests` and `MassiveAPI.Responses`.
- Consistent error handling via `MassiveApiException`.
- XML documentation across the public API for discoverability.

## Installation

Install from NuGet:

```bash
dotnet add package MassiveAPI
```

Or via the NuGet Package Manager:

```powershell
Install-Package MassiveAPI
```

## Quick start

```csharp
using MassiveAPI;
using MassiveAPI.Requests;

var client = new MassiveClient("YOUR_API_KEY");

// Ticker overview
var overview = await client.GetTickerOverviewAsync(new TickerOverviewRequest("AAPL"));

// All tickers
var allTickers = await client.GetAllTickersAsync(new AllTickersRequest
{
    Market = "stocks",
    Active = true,
    Limit = 50
});

// Stock custom bars
var customBars = await client.GetCustomBarsAsync(new CustomBarsRequest
{
    Ticker = "AAPL",
    Multiplier = 1,
    Timespan = "day",
    From = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
    To = new DateTimeOffset(2024, 2, 1, 0, 0, 0, TimeSpan.Zero),
    Adjusted = true
});

// Options custom bars
var optionsBars = await client.GetOptionsCustomBarsAsync(new OptionsCustomBarsRequest
{
    Ticker = "O:AAPL240621C00150000",
    Multiplier = 1,
    Timespan = "day",
    From = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
    To = new DateTimeOffset(2024, 2, 1, 0, 0, 0, TimeSpan.Zero)
});

// Options contract overview
var contractOverview = await client.GetOptionsContractOverviewAsync(
    new OptionsContractOverviewRequest("O:AAPL260102C00110000"));
```

## Error handling

All Massive API failures and serialization issues are wrapped in `MassiveApiException`.
Network cancellations still propagate `OperationCanceledException` for standard cancellation
handling.

## Test project

The test project lives under `tests/MassiveAPI.UnitTests.csproj` and uses xUnit. End-to-end tests
require the `MASSIVE_API_KEY` environment variable to be set; otherwise those tests will return
without executing API calls.

Run tests locally with:

```bash
dotnet test tests/MassiveAPI.UnitTests.csproj
```

## Project structure

- `src/Requests`: Request DTOs used for API calls.
- `src/Responses`: Response DTOs returned by API calls.
- `src/MassiveClient.cs`: `MassiveClient` implementation.
- `src/IMassiveClient.cs`: Interface for the client.

## Development

Build the project with:

```bash
dotnet build src/MassiveAPI.csproj
```
