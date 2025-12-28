using MassiveAPI.Helpers;
using Xunit;

namespace MassiveAPI.UnitTests;

public sealed class OptionsTickerTests
{
    [Fact]
    public void ToString_FormatsTickerUsingComponents()
    {
        var ticker = new OptionsTicker(
            underlyingTicker: "AAPL",
            expirationDate: new DateOnly(2024, 6, 21),
            contractType: OptionContractType.Call,
            strikePrice: 150m);

        var result = ticker.ToString();

        Assert.Equal("AAPL  240621C00150000", result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_ThrowsForInvalidStrike(decimal strike)
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            new OptionsTicker("AAPL", new DateOnly(2024, 6, 21), OptionContractType.Call, strike));

        Assert.Contains("Strike price", exception.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void Constructor_ThrowsForMissingUnderlyingTicker()
    {
        var exception = Assert.Throws<ArgumentException>(() =>
            new OptionsTicker(" ", new DateOnly(2024, 6, 21), OptionContractType.Call, 150m));

        Assert.Contains("Underlying ticker", exception.Message, StringComparison.OrdinalIgnoreCase);
    }
}
