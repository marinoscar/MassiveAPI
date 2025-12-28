using System.Net;
using System.Text;
using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientHttpTests
{
    [Fact]
    public async Task GetAllTickersAsync_AppendsQueryParameters()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\",\"results\":[]}");
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new AllTickersRequest
        {
            Market = "stocks",
            Active = true,
            Limit = 10
        };

        await client.GetAllTickersAsync(request);

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("stocks/tickers", uri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("market=stocks", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("active=true", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("limit=10", uri!.Query, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task GetTickerOverviewAsync_ThrowsMassiveApiExceptionOnHttpFailure()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{}", HttpStatusCode.InternalServerError);
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new TickerOverviewRequest("AAPL");

        var exception = await Assert.ThrowsAsync<MassiveApiException>(() => client.GetTickerOverviewAsync(request));

        Assert.Contains("ticker overview", exception.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task GetTickerOverviewAsync_ThrowsMassiveApiExceptionOnInvalidJson()
    {
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent("invalid-json", Encoding.UTF8, "application/json")
        };
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new TickerOverviewRequest("AAPL");

        var exception = await Assert.ThrowsAsync<MassiveApiException>(() => client.GetTickerOverviewAsync(request));

        Assert.Contains("deserialize", exception.Message, StringComparison.OrdinalIgnoreCase);
    }
}
