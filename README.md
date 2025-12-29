# MassiveAPI

A typed C# client library for the Massive REST API. The library provides request/response models
and a `MassiveClient` implementation (plus `IMassiveClient`) for interacting with the Massive
endpoints using strongly-typed inputs and outputs.

**Keywords:** Massive API, Massive REST API, stocks, options, tickers, aggregates, C# SDK, .NET client.

## Features

- Typed request/response models organized under `MassiveAPI.Requests` and `MassiveAPI.Responses`.
- Consistent error handling via `MassiveApiException`.
- XML documentation across the public API for discoverability.

## Why MassiveAPI?

- **Build AI agents with market awareness.** Pull real-time and historical market data to give your
  agents up-to-date context for trading signals, alerts, or portfolio insights.
- **Strong typing, fewer runtime surprises.** Request/response models are explicit and discoverable
  in IntelliSense.
- **Consistent error handling.** API failures are surfaced as `MassiveApiException` for predictable
  control flow.

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

## Get an API key

To authenticate requests, create an API key in the Massive dashboard and pass it to
`MassiveClient`. See the official quickstart for step-by-step instructions:
https://massive.com/docs/rest/quickstart#authenticate-your-request

## Common use cases

- **AI agent context enrichment:** Fetch the latest ticker overview or aggregates to give your
  agent market-aware context before it responds.
- **Price history & aggregates:** Retrieve custom bars for backtesting, charting, or ML feature
  generation.
- **Options analysis:** Pull options contract details and historical bars for volatility or strategy
  evaluation.
- **Watchlists & discovery:** List active tickers by market to build scanners or alerting systems.
- **Market alerts:** Poll key symbols and trigger notifications on threshold or volume changes.

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
