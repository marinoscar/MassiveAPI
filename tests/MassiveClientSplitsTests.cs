using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientSplitsTests
{
    [Fact]
    public async Task GetSplitsAsync_AppendsQueryParameters()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\",\"results\":[]}");
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new SplitsRequest
        {
            Ticker = "AAPL",
            AdjustmentType = "forward_split",
            Limit = 10
        };

        await client.GetSplitsAsync(request);

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("stocks/v1/splits", uri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("ticker=AAPL", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("adjustment_type=forward_split", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("limit=10", uri!.Query, StringComparison.OrdinalIgnoreCase);
    }
}
