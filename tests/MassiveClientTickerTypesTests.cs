using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientTickerTypesTests
{
    [Fact]
    public async Task GetTickerTypesAsync_AppendsQueryParameters()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\",\"results\":[]}");
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new TickerTypesRequest
        {
            AssetClass = "stocks",
            Locale = "us"
        };

        await client.GetTickerTypesAsync(request);

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("tickers/types", uri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("asset_class=stocks", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("locale=us", uri!.Query, StringComparison.OrdinalIgnoreCase);
    }
}
