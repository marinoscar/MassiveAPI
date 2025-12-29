using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientMovingAverageConvergenceDivergenceTests
{
    [Fact]
    public async Task GetMovingAverageConvergenceDivergenceAsync_AppendsQueryParameters()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\",\"results\":{}}" );
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new MovingAverageConvergenceDivergenceRequest("AAPL")
        {
            ShortWindow = 12,
            LongWindow = 26,
            SignalWindow = 9,
            Timespan = "day",
            Adjusted = true,
            Limit = 5
        };

        await client.GetMovingAverageConvergenceDivergenceAsync(request);

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("v1/indicators/macd/AAPL", uri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("short_window=12", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("long_window=26", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("signal_window=9", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("timespan=day", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("adjusted=true", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("limit=5", uri!.Query, StringComparison.OrdinalIgnoreCase);
    }
}
