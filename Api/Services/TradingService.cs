using Api.Adapters;
using Api.Models.Binance;
using Coinbase.Models;
using Newtonsoft.Json;
using Api.Helpers;

namespace Api.Services;
public interface ITradingService {
    public Task<Buy[]> GetSuccessfulBuyOrdersFromCoinbase(string accountId);
    public Task<Sell[]> GetSuccessfulSellOrdersFromCoinbase(string accountId);
    public Task<SpotOrder[]> GetSuccessfulBuyOrdersFromBinance(string symbol, int years);
    public Task<string> GetSuccessfulSellOrdersFromBinance();
    public Task<string> GetTickersFromBinance();
    public Task<SpotOrder[]> GetExecutedOrdersFromBinance(string symbol);
}
public class TradingService : ITradingService {
    private ICoinbaseAdapter _coinbaseAdapter { get; set; }
    private IBinanceAdapter _binanceAdapter { get; set; }
    public TradingService(ICoinbaseAdapter coinhbaseAdapter, IBinanceAdapter binanceAdapter) {
        _coinbaseAdapter = coinhbaseAdapter;
        _binanceAdapter = binanceAdapter;
    }

    public async Task<Buy[]> GetSuccessfulBuyOrdersFromCoinbase(string accountId)
    {
        return await _coinbaseAdapter.GetCompletedBuyOrders(accountId);
    }

    public async Task<Sell[]> GetSuccessfulSellOrdersFromCoinbase(string accountId)
    {
        return await _coinbaseAdapter.GetCompletedSellOrders(accountId);
    }

    public async Task<SpotOrder[]> GetSuccessfulBuyOrdersFromBinance(string symbol, int years)
    {
        return await _binanceAdapter.GetAllExecutedBuyOrders(symbol, years);
    }

    public Task<string> GetSuccessfulSellOrdersFromBinance()
    {
        throw new NotImplementedException();
    }

    public async Task<string> GetTickersFromBinance()
    {
        return await _binanceAdapter.GetTickers();
    }

    public async Task<SpotOrder[]> GetExecutedOrdersFromBinance(string symbol)
    {
        var startDateInUnix = 1483225200; //2017-01-01 00:00:00
        var orders = await _binanceAdapter.GetAllExecutedOrders(symbol, startTime: startDateInUnix);
        return orders;
    }
}