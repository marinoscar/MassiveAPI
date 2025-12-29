using System.Net;
using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientNotAuthorizedTests
{
    [Fact]
    public async Task GetTickerOverviewAsync_ThrowsNotAuthorizedException()
    {
        var payload = "{\"status\":\"NOT_AUTHORIZED\",\"request_id\":\"req-123\",\"message\":\"You are not entitled\"}";
        var response = new HttpResponseMessage(HttpStatusCode.Forbidden)
        {
            Content = new StringContent(payload)
        };
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var exception = await Assert.ThrowsAsync<MassiveNotAuthorizedException>(() =>
            client.GetTickerOverviewAsync(new TickerOverviewRequest("AAPL")));

        Assert.Equal("req-123", exception.RequestId);
        Assert.Contains("not entitled", exception.Message, StringComparison.OrdinalIgnoreCase);
    }
}
