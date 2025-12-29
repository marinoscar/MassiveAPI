using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientOptionsPreviousDayBarTests
{
    [Fact]
    public async Task GetOptionsPreviousDayBarAsync_AppendsQueryParameters()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\",\"results\":[]}" );
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new OptionsPreviousDayBarRequest("O:TSLA210903C00700000")
        {
            Adjusted = false
        };

        await client.GetOptionsPreviousDayBarAsync(request);

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("v2/aggs/ticker/O:TSLA210903C00700000/prev", Uri.UnescapeDataString(uri!.AbsoluteUri), StringComparison.OrdinalIgnoreCase);
        Assert.Contains("adjusted=false", uri!.Query, StringComparison.OrdinalIgnoreCase);
    }
}
