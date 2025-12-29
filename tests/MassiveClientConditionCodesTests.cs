using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientConditionCodesTests
{
    [Fact]
    public async Task GetConditionCodesAsync_AppendsQueryParameters()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\",\"results\":[]}");
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new ConditionCodesRequest
        {
            AssetClass = "stocks",
            Locale = "us"
        };

        await client.GetConditionCodesAsync(request);

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("condition-codes", uri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("asset_class=stocks", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("locale=us", uri!.Query, StringComparison.OrdinalIgnoreCase);
    }
}
