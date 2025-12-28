namespace MassiveAPI.Helpers;

/// <summary>
/// Builds an options ticker string from its component parts.
/// </summary>
public sealed class OptionsTicker
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OptionsTicker"/> class.
    /// </summary>
    /// <param name="underlyingTicker">The underlying equity ticker.</param>
    /// <param name="expirationDate">The contract expiration date.</param>
    /// <param name="contractType">The contract type (call or put).</param>
    /// <param name="strikePrice">The strike price in dollars.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="underlyingTicker"/> is null or whitespace.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="strikePrice"/> is less than or equal to zero.
    /// </exception>
    public OptionsTicker(
        string underlyingTicker,
        DateOnly expirationDate,
        OptionContractType contractType,
        decimal strikePrice)
    {
        if (string.IsNullOrWhiteSpace(underlyingTicker))
        {
            throw new ArgumentException("Underlying ticker is required.", nameof(underlyingTicker));
        }

        if (strikePrice <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(strikePrice), "Strike price must be greater than zero.");
        }

        UnderlyingTicker = underlyingTicker.Trim().ToUpperInvariant();
        ExpirationDate = expirationDate;
        ContractType = contractType;
        StrikePrice = strikePrice;
    }

    /// <summary>
    /// Gets the underlying equity ticker.
    /// </summary>
    public string UnderlyingTicker { get; }

    /// <summary>
    /// Gets the contract expiration date.
    /// </summary>
    public DateOnly ExpirationDate { get; }

    /// <summary>
    /// Gets the contract type.
    /// </summary>
    public OptionContractType ContractType { get; }

    /// <summary>
    /// Gets the strike price in dollars.
    /// </summary>
    public decimal StrikePrice { get; }

    /// <summary>
    /// Returns the formatted options ticker.
    /// </summary>
    /// <returns>The formatted options ticker string.</returns>
    public override string ToString()
    {
        var underlying = UnderlyingTicker.PadRight(6, ' ');
        var expiration = ExpirationDate.ToString("yyMMdd");
        var type = ContractType == OptionContractType.Call ? 'C' : 'P';
        var strike = (int)Math.Round(StrikePrice * 1000m, MidpointRounding.AwayFromZero);
        var strikeFormatted = strike.ToString("D8");

        return $"{underlying}{expiration}{type}{strikeFormatted}";
    }
}

/// <summary>
/// Indicates the contract type for an options ticker.
/// </summary>
public enum OptionContractType
{
    /// <summary>
    /// A call option contract.
    /// </summary>
    Call,

    /// <summary>
    /// A put option contract.
    /// </summary>
    Put
}
