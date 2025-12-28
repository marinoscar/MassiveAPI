using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientMarketHolidaysTests
{
    [Fact]
    public async Task GetMarketHolidaysAsync_AppendsQueryParameters()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\",\"results\":[]}");
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new MarketHolidaysRequest
        {
            Market = "stocks",
            Exchange = "XNYS",
            Locale = "us"
        };

        await client.GetMarketHolidaysAsync(request);

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("market-holidays", uri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("market=stocks", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("exchange=XNYS", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("locale=us", uri!.Query, StringComparison.OrdinalIgnoreCase);
    }
}
