using System.Net;
using MassiveAPI.Requests;

namespace MassiveAPI.Builders;

internal static class QueryStringBuilder
{
    public static string Build(AllTickersRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "ticker", request.Ticker);
        AddParameter(parameters, "market", request.Market);
        AddParameter(parameters, "locale", request.Locale);
        AddParameter(parameters, "type", request.Type);
        AddParameter(parameters, "search", request.Search);
        AddParameter(parameters, "active", request.Active?.ToString().ToLowerInvariant());
        AddParameter(parameters, "sort", request.Sort);
        AddParameter(parameters, "order", request.Order);
        AddParameter(parameters, "limit", request.Limit?.ToString());
        AddParameter(parameters, "cursor", request.Cursor);

        return string.Join("&", parameters);
    }

    public static string Build(OptionsContractsRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "ticker", request.Ticker);
        AddParameter(parameters, "underlying_ticker", request.UnderlyingTicker);
        AddParameter(parameters, "contract_type", request.ContractType);
        AddParameter(parameters, "expiration_date", request.ExpirationDate?.ToString("yyyy-MM-dd"));
        AddParameter(parameters, "strike_price", request.StrikePrice?.ToString());
        AddParameter(parameters, "sort", request.Sort);
        AddParameter(parameters, "order", request.Order);
        AddParameter(parameters, "limit", request.Limit?.ToString());
        AddParameter(parameters, "cursor", request.Cursor);

        return string.Join("&", parameters);
    }

    public static string Build(TickerTypesRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "asset_class", request.AssetClass);
        AddParameter(parameters, "locale", request.Locale);

        return string.Join("&", parameters);
    }

    public static string Build(DailyMarketSummaryRequest request)
    {
        var parameters = new List<string>();

        return string.Join("&", parameters);
    }

    public static string Build(DailyTickerSummaryRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "adjusted", request.Adjusted?.ToString().ToLowerInvariant());
        AddParameter(parameters, "locale", request.Locale);

        return string.Join("&", parameters);
    }

    public static string Build(PreviousDayBarRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "adjusted", request.Adjusted?.ToString().ToLowerInvariant());

        return string.Join("&", parameters);
    }

    public static string Build(SimpleMovingAverageRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "window", request.Window?.ToString());
        AddParameter(parameters, "limit", request.Limit?.ToString());
        AddParameter(parameters, "timestamp", request.Timestamp?.ToString("O"));
        AddParameter(parameters, "timestamp_lt", request.TimestampLessThan?.ToString("O"));
        AddParameter(parameters, "timestamp_gt", request.TimestampGreaterThan?.ToString("O"));
        AddParameter(parameters, "timespan", request.Timespan);
        AddParameter(parameters, "adjusted", request.Adjusted?.ToString().ToLowerInvariant());
        AddParameter(parameters, "sort", request.Sort);
        AddParameter(parameters, "order", request.Order);
        AddParameter(parameters, "expand", request.Expand?.ToString().ToLowerInvariant());

        return string.Join("&", parameters);
    }

    public static string Build(ExponentialMovingAverageRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "window", request.Window?.ToString());
        AddParameter(parameters, "limit", request.Limit?.ToString());
        AddParameter(parameters, "timestamp", request.Timestamp?.ToString("O"));
        AddParameter(parameters, "timestamp_lt", request.TimestampLessThan?.ToString("O"));
        AddParameter(parameters, "timestamp_gt", request.TimestampGreaterThan?.ToString("O"));
        AddParameter(parameters, "timespan", request.Timespan);
        AddParameter(parameters, "adjusted", request.Adjusted?.ToString().ToLowerInvariant());
        AddParameter(parameters, "sort", request.Sort);
        AddParameter(parameters, "order", request.Order);
        AddParameter(parameters, "expand", request.Expand?.ToString().ToLowerInvariant());

        return string.Join("&", parameters);
    }

    public static string Build(MovingAverageConvergenceDivergenceRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "limit", request.Limit?.ToString());
        AddParameter(parameters, "timestamp", request.Timestamp?.ToString("O"));
        AddParameter(parameters, "timestamp_lt", request.TimestampLessThan?.ToString("O"));
        AddParameter(parameters, "timestamp_gt", request.TimestampGreaterThan?.ToString("O"));
        AddParameter(parameters, "timespan", request.Timespan);
        AddParameter(parameters, "adjusted", request.Adjusted?.ToString().ToLowerInvariant());
        AddParameter(parameters, "short_window", request.ShortWindow?.ToString());
        AddParameter(parameters, "long_window", request.LongWindow?.ToString());
        AddParameter(parameters, "signal_window", request.SignalWindow?.ToString());
        AddParameter(parameters, "sort", request.Sort);
        AddParameter(parameters, "order", request.Order);
        AddParameter(parameters, "expand", request.Expand?.ToString().ToLowerInvariant());

        return string.Join("&", parameters);
    }

    public static string Build(RelativeStrengthIndexRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "window", request.Window?.ToString());
        AddParameter(parameters, "limit", request.Limit?.ToString());
        AddParameter(parameters, "timestamp", request.Timestamp?.ToString("O"));
        AddParameter(parameters, "timestamp_lt", request.TimestampLessThan?.ToString("O"));
        AddParameter(parameters, "timestamp_gt", request.TimestampGreaterThan?.ToString("O"));
        AddParameter(parameters, "timespan", request.Timespan);
        AddParameter(parameters, "adjusted", request.Adjusted?.ToString().ToLowerInvariant());
        AddParameter(parameters, "sort", request.Sort);
        AddParameter(parameters, "order", request.Order);
        AddParameter(parameters, "expand", request.Expand?.ToString().ToLowerInvariant());

        return string.Join("&", parameters);
    }

    public static string Build(ExchangesRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "asset_class", request.AssetClass);
        AddParameter(parameters, "locale", request.Locale);

        return string.Join("&", parameters);
    }

    public static string Build(MarketHolidaysRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "market", request.Market);
        AddParameter(parameters, "exchange", request.Exchange);
        AddParameter(parameters, "locale", request.Locale);

        return string.Join("&", parameters);
    }

    public static string Build(ConditionCodesRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "asset_class", request.AssetClass);
        AddParameter(parameters, "locale", request.Locale);

        return string.Join("&", parameters);
    }

    public static string Build(FuturesExchangesRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "limit", request.Limit?.ToString());

        return string.Join("&", parameters);
    }

    public static string Build(InitialPublicOfferingsRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "ticker", request.Ticker);
        AddParameter(parameters, "us_code", request.UsCode);
        AddParameter(parameters, "isin", request.Isin);
        AddParameter(parameters, "listing_date", request.ListingDate?.ToString("yyyy-MM-dd"));
        AddParameter(parameters, "ipo_status", request.IpoStatus);
        AddParameter(parameters, "listing_date.gte", request.ListingDateGreaterThanOrEqual?.ToString("yyyy-MM-dd"));
        AddParameter(parameters, "listing_date.gt", request.ListingDateGreaterThan?.ToString("yyyy-MM-dd"));
        AddParameter(parameters, "listing_date.lte", request.ListingDateLessThanOrEqual?.ToString("yyyy-MM-dd"));
        AddParameter(parameters, "listing_date.lt", request.ListingDateLessThan?.ToString("yyyy-MM-dd"));
        AddParameter(parameters, "order", request.Order);
        AddParameter(parameters, "limit", request.Limit?.ToString());
        AddParameter(parameters, "sort", request.Sort);

        return string.Join("&", parameters);
    }

    public static string Build(SplitsRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "ticker", request.Ticker);
        AddParameter(parameters, "ticker.any_of", request.TickerAnyOf);
        AddParameter(parameters, "ticker.gt", request.TickerGreaterThan);
        AddParameter(parameters, "ticker.gte", request.TickerGreaterThanOrEqual);
        AddParameter(parameters, "ticker.lt", request.TickerLessThan);
        AddParameter(parameters, "ticker.lte", request.TickerLessThanOrEqual);
        AddParameter(parameters, "execution_date", request.ExecutionDate?.ToString("yyyy-MM-dd"));
        AddParameter(parameters, "execution_date.gt", request.ExecutionDateGreaterThan?.ToString("yyyy-MM-dd"));
        AddParameter(parameters, "execution_date.gte", request.ExecutionDateGreaterThanOrEqual?.ToString("yyyy-MM-dd"));
        AddParameter(parameters, "execution_date.lt", request.ExecutionDateLessThan?.ToString("yyyy-MM-dd"));
        AddParameter(parameters, "execution_date.lte", request.ExecutionDateLessThanOrEqual?.ToString("yyyy-MM-dd"));
        AddParameter(parameters, "adjustment_type", request.AdjustmentType);
        AddParameter(parameters, "adjustment_type.any_of", request.AdjustmentTypeAnyOf);
        AddParameter(parameters, "limit", request.Limit?.ToString());
        AddParameter(parameters, "sort", request.Sort);

        return string.Join("&", parameters);
    }

    public static string Build(DividendsRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "ticker", request.Ticker);
        AddParameter(parameters, "ticker.any_of", request.TickerAnyOf);
        AddParameter(parameters, "ticker.gt", request.TickerGreaterThan);
        AddParameter(parameters, "ticker.gte", request.TickerGreaterThanOrEqual);
        AddParameter(parameters, "ticker.lt", request.TickerLessThan);
        AddParameter(parameters, "ticker.lte", request.TickerLessThanOrEqual);
        AddParameter(parameters, "ex_dividend_date", request.ExDividendDate?.ToString("yyyy-MM-dd"));
        AddParameter(parameters, "ex_dividend_date.gt", request.ExDividendDateGreaterThan?.ToString("yyyy-MM-dd"));
        AddParameter(parameters, "ex_dividend_date.gte", request.ExDividendDateGreaterThanOrEqual?.ToString("yyyy-MM-dd"));
        AddParameter(parameters, "ex_dividend_date.lt", request.ExDividendDateLessThan?.ToString("yyyy-MM-dd"));
        AddParameter(parameters, "ex_dividend_date.lte", request.ExDividendDateLessThanOrEqual?.ToString("yyyy-MM-dd"));
        AddParameter(parameters, "frequency", request.Frequency?.ToString());
        AddParameter(parameters, "frequency.gt", request.FrequencyGreaterThan?.ToString());
        AddParameter(parameters, "frequency.gte", request.FrequencyGreaterThanOrEqual?.ToString());
        AddParameter(parameters, "frequency.lt", request.FrequencyLessThan?.ToString());
        AddParameter(parameters, "frequency.lte", request.FrequencyLessThanOrEqual?.ToString());
        AddParameter(parameters, "distribution_type", request.DistributionType);
        AddParameter(parameters, "distribution_type.any_of", request.DistributionTypeAnyOf);
        AddParameter(parameters, "limit", request.Limit?.ToString());
        AddParameter(parameters, "sort", request.Sort);

        return string.Join("&", parameters);
    }

    public static string Build(TickerEventsRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "types", request.Types);

        return string.Join("&", parameters);
    }

    public static string Build(OptionsDailyTickerSummaryRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "adjusted", request.Adjusted?.ToString().ToLowerInvariant());

        return string.Join("&", parameters);
    }

    public static string Build(OptionsPreviousDayBarRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "adjusted", request.Adjusted?.ToString().ToLowerInvariant());

        return string.Join("&", parameters);
    }

    public static string Build(OptionsCustomBarsRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "adjusted", request.Adjusted?.ToString().ToLowerInvariant());
        AddParameter(parameters, "sort", request.Sort);
        AddParameter(parameters, "limit", request.Limit?.ToString());

        return string.Join("&", parameters);
    }

    public static string Build(CustomBarsRequest request)
    {
        var parameters = new List<string>();

        AddParameter(parameters, "adjusted", request.Adjusted?.ToString().ToLowerInvariant());
        AddParameter(parameters, "sort", request.Sort);
        AddParameter(parameters, "limit", request.Limit?.ToString());

        return string.Join("&", parameters);
    }

    private static void AddParameter(ICollection<string> parameters, string name, string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return;
        }

        parameters.Add($"{WebUtility.UrlEncode(name)}={WebUtility.UrlEncode(value)}");
    }
}
