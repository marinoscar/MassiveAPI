using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientOptionsDailyTickerSummaryTests
{
    [Fact]
    public async Task GetOptionsDailyTickerSummaryAsync_AppendsQueryParameters()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\"}" );
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new OptionsDailyTickerSummaryRequest("O:TSLA210903C00700000", new DateOnly(2023, 1, 9))
        {
            Adjusted = false
        };

        await client.GetOptionsDailyTickerSummaryAsync(request);

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("v1/open-close/O:TSLA210903C00700000/2023-01-09", Uri.UnescapeDataString(uri!.AbsoluteUri), StringComparison.OrdinalIgnoreCase);
        Assert.Contains("adjusted=false", uri!.Query, StringComparison.OrdinalIgnoreCase);
    }
}
