using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientTickerEventsTests
{
    [Fact]
    public async Task GetTickerEventsAsync_AppendsQueryParameters()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\",\"results\":{}}" );
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new TickerEventsRequest("AAPL")
        {
            Types = "ticker_change"
        };

        await client.GetTickerEventsAsync(request);

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("tickers/AAPL/events", uri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("types=ticker_change", uri!.Query, StringComparison.OrdinalIgnoreCase);
    }
}
