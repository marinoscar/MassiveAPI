using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientRelativeStrengthIndexTests
{
    [Fact]
    public async Task GetRelativeStrengthIndexAsync_AppendsQueryParameters()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\",\"results\":{}}" );
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new RelativeStrengthIndexRequest("AAPL")
        {
            Window = 14,
            Timespan = "day",
            Adjusted = true,
            Limit = 5
        };

        await client.GetRelativeStrengthIndexAsync(request);

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("v1/indicators/sma/AAPL", uri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("window=14", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("timespan=day", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("adjusted=true", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("limit=5", uri!.Query, StringComparison.OrdinalIgnoreCase);
    }
}
