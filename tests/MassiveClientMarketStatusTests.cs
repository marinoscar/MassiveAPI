using MassiveAPI;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientMarketStatusTests
{
    [Fact]
    public async Task GetMarketStatusAsync_UsesEndpoint()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\",\"results\":{}}" );
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        await client.GetMarketStatusAsync();

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("v1/marketstatus/now", uri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
    }
}
