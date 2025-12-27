# MassiveAPI

A typed C# client library for the Massive REST API. The library provides request/response models,
helper utilities, and a `MassiveClient` implementation (plus `IMassiveClient`) for interacting
with the Massive endpoints using strongly-typed inputs and outputs.

## Features

- Typed request/response models organized under `MassiveAPI.Requests` and `MassiveAPI.Responses`.
- Helper utilities such as `OptionsTicker` for building options ticker strings.
- Consistent error handling via `MassiveApiException`.
- XML documentation across the public API for discoverability.

## Installation

This project is currently a source-only library. Add the `src` project to your solution, or
reference the compiled assembly once you build it.

## Quick start

```csharp
using MassiveAPI;
using MassiveAPI.Helpers;
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
    Ticker = "AAPL240621C00150000",
    Multiplier = 1,
    Timespan = "day",
    From = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
    To = new DateTimeOffset(2024, 2, 1, 0, 0, 0, TimeSpan.Zero)
});

// Options contract overview using OptionsTicker helper
var optionsTicker = new OptionsTicker(
    underlyingTicker: "AAPL",
    expirationDate: new DateOnly(2024, 6, 21),
    contractType: OptionContractType.Call,
    strikePrice: 150m);

var contractOverview = await client.GetOptionsContractOverviewAsync(new OptionsContractOverviewRequest
{
    OptionsTicker = optionsTicker
});
```

## Error handling

All Massive API failures and serialization issues are wrapped in `MassiveApiException`.
Network cancellations still propagate `OperationCanceledException` for standard cancellation
handling.

## Project structure

- `src/Requests`: Request DTOs used for API calls.
- `src/Responses`: Response DTOs returned by API calls.
- `src/Helpers`: Helper utilities (for example, `OptionsTicker`).
- `src/MassiveClient.cs`: `MassiveClient` implementation.
- `src/IMassiveClient.cs`: Interface for the client.

## Development

Build the project with:

```bash
dotnet build src/MassiveAPI.csproj
```
