using MassiveAPI;
using MassiveAPI.Requests;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class MassiveClientEndToEndTests
{
    private static MassiveClient? CreateClient()
    {
        var apiKey = Environment.GetEnvironmentVariable("MASSIVE_API_KEY");
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            return null;
        }

        return new MassiveClient(apiKey);
    }

    [Fact]
    public async Task GetTickerOverviewAsync_ReturnsData()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        var response = await client.GetTickerOverviewAsync(new TickerOverviewRequest("AAPL"));

        Assert.NotNull(response);
        Assert.False(string.IsNullOrWhiteSpace(response.Status));
    }

    [Fact]
    public async Task GetAllTickersAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        var response = await client.GetAllTickersAsync(new AllTickersRequest
        {
            Market = "stocks",
            Limit = 1
        });

        Assert.NotNull(response);
        Assert.False(string.IsNullOrWhiteSpace(response.Status));
    }

    [Fact]
    public async Task GetOptionsContractOverviewAsync_ReturnsData()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        var response = await client.GetOptionsContractOverviewAsync(
            new OptionsContractOverviewRequest("O:AAPL260102C00110000"));

        Assert.NotNull(response);
        Assert.False(string.IsNullOrWhiteSpace(response.Status));
    }

    [Fact]
    public async Task GetOptionsContractsAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        var response = await client.GetOptionsContractsAsync(new OptionsContractsRequest
        {
            UnderlyingTicker = "AAPL",
            Limit = 1
        });

        Assert.NotNull(response);
        Assert.False(string.IsNullOrWhiteSpace(response.Status));
    }

    [Fact]
    public async Task GetTickerTypesAsync_ReturnsResults()
    {
        var client = CreateClient();
        if (client is null)
        {
            return;
        }

        var response = await client.GetTickerTypesAsync(new TickerTypesRequest
        {
            AssetClass = "stocks",
            Locale = "us"
        });

        Assert.NotNull(response);
        Assert.False(string.IsNullOrWhiteSpace(response.Status));
    }
}
