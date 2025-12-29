using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientEndToEndTests
{
    /// <summary>
    /// Delay between live API calls to respect the 5 requests per 60 seconds rate limit.
    /// </summary>
    private const int RateLimitDelaySeconds = 13;

    private readonly ITestOutputHelper _output;

    public MassiveClientEndToEndTests(ITestOutputHelper output)
    {
        _output = output;
    }

    private static MassiveClient? CreateClient()
    {
        var apiKey = Environment.GetEnvironmentVariable("MASSIVE_API_KEY");
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            return null;
        }

        return new MassiveClient(apiKey);
    }

    private void WarnIfNotAuthorized(MassiveNotAuthorizedException ex)
    {
        
        _output.WriteLine($"WARNING: Not authorized for this endpoint. RequestId={ex.RequestId}. Message={ex.Message}");
    }

    /// <summary>
    /// Waits long enough between live API calls to avoid rate limiting.
    /// </summary>
    private static Task WaitForRateLimitAsync()
    {
        return Task.Delay(TimeSpan.FromSeconds(RateLimitDelaySeconds));
    }

    [Fact]
    public async Task GetTickerOverviewAsync_ReturnsData()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetTickerOverviewAsync(new TickerOverviewRequest("AAPL"));

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetAllTickersAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetAllTickersAsync(new AllTickersRequest
            {
                Market = "stocks",
                Limit = 1
            });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetOptionsContractOverviewAsync_ReturnsData()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetOptionsContractOverviewAsync(
                new OptionsContractOverviewRequest("O:AAPL260102C00110000"));

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetOptionsContractsAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetOptionsContractsAsync(new OptionsContractsRequest
            {
                UnderlyingTicker = "AAPL",
                Limit = 1
            });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetTickerTypesAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetTickerTypesAsync(new TickerTypesRequest
            {
                AssetClass = "stocks",
                Locale = "us"
            });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetRelatedTickersAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetRelatedTickersAsync(new RelatedTickersRequest("AAPL"));

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetDailyMarketSummaryAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var date = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1));
            var response = await client.GetDailyMarketSummaryAsync(new DailyMarketSummaryRequest(date)
            {
                Market = "stocks",
                Locale = "us"
            });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetDailyTickerSummaryAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var date = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1));
            var response = await client.GetDailyTickerSummaryAsync(new DailyTickerSummaryRequest("AAPL", date)
            {
                Adjusted = true,
                Locale = "us"
            });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetPreviousDayBarAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetPreviousDayBarAsync(new PreviousDayBarRequest("AAPL")
            {
                Adjusted = true
            });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetSimpleMovingAverageAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetSimpleMovingAverageAsync(new SimpleMovingAverageRequest("AAPL")
            {
                Window = 10,
                Timespan = "day",
                Adjusted = true,
                Limit = 5
            });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetExponentialMovingAverageAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetExponentialMovingAverageAsync(new ExponentialMovingAverageRequest("AAPL")
            {
                Window = 10,
                Timespan = "day",
                Adjusted = true,
                Limit = 5
            });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetMovingAverageConvergenceDivergenceAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetMovingAverageConvergenceDivergenceAsync(new MovingAverageConvergenceDivergenceRequest("AAPL")
            {
                ShortWindow = 12,
                LongWindow = 26,
                SignalWindow = 9,
                Timespan = "day",
                Adjusted = true,
                Limit = 5
            });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetRelativeStrengthIndexAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetRelativeStrengthIndexAsync(new RelativeStrengthIndexRequest("AAPL")
            {
                Window = 14,
                Timespan = "day",
                Adjusted = true,
                Limit = 5
            });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetExchangesAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetExchangesAsync(new ExchangesRequest
            {
                AssetClass = "stocks",
                Locale = "us"
            });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetMarketHolidaysAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetMarketHolidaysAsync(new MarketHolidaysRequest
            {
                Market = "stocks",
                Exchange = "XNYS",
                Locale = "us"
            });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetMarketStatusAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetMarketStatusAsync();

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetConditionCodesAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetConditionCodesAsync(new ConditionCodesRequest
            {
                AssetClass = "stocks",
                Locale = "us"
            });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetFuturesExchangesAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetFuturesExchangesAsync(new FuturesExchangesRequest
            {
                Limit = 50
            });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetInitialPublicOfferingsAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetInitialPublicOfferingsAsync(new InitialPublicOfferingsRequest
            {
                IpoStatus = "history",
                Limit = 1
            });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetSplitsAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetSplitsAsync(new SplitsRequest
            {
                Ticker = "AAPL",
                Limit = 1
            });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetDividendsAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetDividendsAsync(new DividendsRequest
            {
                Ticker = "AAPL",
                Limit = 1
            });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetTickerEventsAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetTickerEventsAsync(new TickerEventsRequest("AAPL"));

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetOptionsDailyTickerSummaryAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetOptionsDailyTickerSummaryAsync(
                new OptionsDailyTickerSummaryRequest("O:TSLA210903C00700000", new DateOnly(2023, 1, 9))
                {
                    Adjusted = false
                });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }

    [Fact]
    public async Task GetOptionsPreviousDayBarAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        try
        {
            await WaitForRateLimitAsync();
            var response = await client.GetOptionsPreviousDayBarAsync(new OptionsPreviousDayBarRequest("O:TSLA210903C00700000")
            {
                Adjusted = false
            });

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Status));
        }
        catch (MassiveNotAuthorizedException ex)
        {
            WarnIfNotAuthorized(ex);
        }
    }
}
