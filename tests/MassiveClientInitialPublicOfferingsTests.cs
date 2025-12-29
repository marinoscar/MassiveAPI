using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientInitialPublicOfferingsTests
{
    [Fact]
    public async Task GetInitialPublicOfferingsAsync_AppendsQueryParameters()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\",\"results\":[]}");
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new InitialPublicOfferingsRequest
        {
            Ticker = "RAPP",
            IpoStatus = "history",
            Limit = 10
        };

        await client.GetInitialPublicOfferingsAsync(request);

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("ipos", uri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("ticker=RAPP", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("ipo_status=history", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("limit=10", uri!.Query, StringComparison.OrdinalIgnoreCase);
    }
}
