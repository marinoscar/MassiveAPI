using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientFuturesExchangesTests
{
    [Fact]
    public async Task GetFuturesExchangesAsync_AppendsQueryParameters()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\",\"results\":[]}");
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new FuturesExchangesRequest
        {
            Limit = 50
        };

        await client.GetFuturesExchangesAsync(request);

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("futures/vX/exchanges", uri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("limit=50", uri!.Query, StringComparison.OrdinalIgnoreCase);
    }
}
