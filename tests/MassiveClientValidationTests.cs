using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientValidationTests
{
    private static MassiveClient CreateClient()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\"}");
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };

        return new MassiveClient("test-key", httpClient, httpClient.BaseAddress);
    }

    [Fact]
    public async Task GetCustomBarsAsync_ThrowsWhenTickerMissing()
    {
        var client = CreateClient();
        var request = new CustomBarsRequest
        {
            Multiplier = 1,
            Timespan = "day",
            From = DateTimeOffset.UtcNow.AddDays(-1),
            To = DateTimeOffset.UtcNow
        };

        var exception = await Assert.ThrowsAsync<ArgumentException>(() => client.GetCustomBarsAsync(request));

        Assert.Contains("Ticker", exception.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task GetCustomBarsAsync_ThrowsWhenMultiplierInvalid()
    {
        var client = CreateClient();
        var request = new CustomBarsRequest
        {
            Ticker = "AAPL",
            Multiplier = 0,
            Timespan = "day",
            From = DateTimeOffset.UtcNow.AddDays(-1),
            To = DateTimeOffset.UtcNow
        };

        var exception = await Assert.ThrowsAsync<ArgumentException>(() => client.GetCustomBarsAsync(request));

        Assert.Contains("Multiplier", exception.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task GetOptionsCustomBarsAsync_ThrowsWhenTimespanMissing()
    {
        var client = CreateClient();
        var request = new OptionsCustomBarsRequest
        {
            Ticker = "AAPL240621C00150000",
            Multiplier = 1,
            From = DateTimeOffset.UtcNow.AddDays(-1),
            To = DateTimeOffset.UtcNow
        };

        var exception = await Assert.ThrowsAsync<ArgumentException>(() => client.GetOptionsCustomBarsAsync(request));

        Assert.Contains("Timespan", exception.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task GetOptionsContractOverviewAsync_ThrowsWhenTickerMissing()
    {
        var client = CreateClient();
        var request = new OptionsContractOverviewRequest("");

        var exception = await Assert.ThrowsAsync<ArgumentException>(() => client.GetOptionsContractOverviewAsync(request));

        Assert.Contains("Options ticker", exception.Message, StringComparison.OrdinalIgnoreCase);
    }
}
