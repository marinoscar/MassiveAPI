using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientDailyMarketSummaryTests
{
    [Fact]
    public async Task GetDailyMarketSummaryAsync_AppendsQueryParameters()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\",\"results\":[]}");
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new DailyMarketSummaryRequest(new DateOnly(2024, 1, 2))
        {
            Market = "stocks",
            Locale = "us"
        };

        await client.GetDailyMarketSummaryAsync(request);

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("stocks/aggregates/daily-market-summary", uri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("date=2024-01-02", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("market=stocks", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("locale=us", uri!.Query, StringComparison.OrdinalIgnoreCase);
    }
}
