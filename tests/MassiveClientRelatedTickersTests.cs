using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientRelatedTickersTests
{
    [Fact]
    public async Task GetRelatedTickersAsync_UsesTickerEndpoint()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\",\"results\":[]}");
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        await client.GetRelatedTickersAsync(new RelatedTickersRequest("AAPL"));

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("tickers/AAPL/related", uri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
    }
}
