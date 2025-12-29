using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientExponentialMovingAverageTests
{
    [Fact]
    public async Task GetExponentialMovingAverageAsync_AppendsQueryParameters()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\",\"results\":{}}" );
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new ExponentialMovingAverageRequest("AAPL")
        {
            Window = 10,
            Timespan = "day",
            Adjusted = true,
            Limit = 5
        };

        await client.GetExponentialMovingAverageAsync(request);

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("stocks/technical-indicators/ema/AAPL", uri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("window=10", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("timespan=day", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("adjusted=true", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("limit=5", uri!.Query, StringComparison.OrdinalIgnoreCase);
    }
}
