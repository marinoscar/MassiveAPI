using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientDividendsTests
{
    [Fact]
    public async Task GetDividendsAsync_AppendsQueryParameters()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\",\"results\":[]}");
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new DividendsRequest
        {
            Ticker = "AAPL",
            DistributionType = "recurring",
            Limit = 10
        };

        await client.GetDividendsAsync(request);

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("stocks/v1/dividends", uri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("ticker=AAPL", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("distribution_type=recurring", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("limit=10", uri!.Query, StringComparison.OrdinalIgnoreCase);
    }
}
