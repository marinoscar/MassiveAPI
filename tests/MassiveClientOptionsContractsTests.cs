using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientOptionsContractsTests
{
    [Fact]
    public async Task GetOptionsContractsAsync_AppendsQueryParameters()
    {
        var response = TestHttpMessageHandler.CreateJsonResponse("{\"status\":\"ok\",\"results\":[]}");
        var handler = new TestHttpMessageHandler(response);
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.test/")
        };
        var client = new MassiveClient("test-key", httpClient, httpClient.BaseAddress);

        var request = new OptionsContractsRequest
        {
            UnderlyingTicker = "AAPL",
            ContractType = "call",
            ExpirationDate = new DateOnly(2025, 1, 17),
            Limit = 5
        };

        await client.GetOptionsContractsAsync(request);

        Assert.NotNull(handler.LastRequest);
        var uri = handler.LastRequest!.RequestUri;
        Assert.NotNull(uri);
        Assert.Contains("options/contracts", uri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("underlying_ticker=AAPL", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("contract_type=call", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("expiration_date=2025-01-17", uri!.Query, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("limit=5", uri!.Query, StringComparison.OrdinalIgnoreCase);
    }
}
