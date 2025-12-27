using MassiveAPI;
using MassiveAPI.Helpers;
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

        var optionsTicker = new OptionsTicker(
            underlyingTicker: "AAPL",
            expirationDate: new DateOnly(2024, 6, 21),
            contractType: OptionContractType.Call,
            strikePrice: 150m);

        var response = await client.GetOptionsContractOverviewAsync(new OptionsContractOverviewRequest
        {
            OptionsTicker = optionsTicker
        });

        Assert.NotNull(response);
        Assert.False(string.IsNullOrWhiteSpace(response.Status));
    }
}
