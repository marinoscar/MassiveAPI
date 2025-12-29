using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientDailyTickerSummaryTests
{
    [Fact]
    public async Task GetDailyTickerSummaryAsync_AppendsQueryParameters()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\",\"results\":{}}" );
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new DailyTickerSummaryRequest("AAPL", new DateOnly(2024, 1, 2))
        {
            Adjusted = true,
            Locale = "us"
        };

        await client.GetDailyTickerSummaryAsync(request);

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("v1/open-close/AAPL/2024-01-02", uri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("adjusted=true", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("locale=us", uri!.Query, StringComparison.OrdinalIgnoreCase);
    }
}
