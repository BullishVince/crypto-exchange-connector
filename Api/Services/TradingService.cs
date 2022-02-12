using Api.Adapters;
using Api.Models.Binance;
using Coinbase.Models;
using Newtonsoft.Json;

namespace Api.Services;
public interface ITradingService {
    public Task<Buy[]> GetSuccessfulBuyOrdersFromCoinbase(string accountId);
    public Task<Sell[]> GetSuccessfulSellOrdersFromCoinbase(string accountId);
    public Task<string> GetSuccessfulBuyOrdersFromBinance();
    public Task<string> GetSuccessfulSellOrdersFromBinance();
    public Task<string> GetTickersFromBinance();
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

    public Task<string> GetSuccessfulBuyOrdersFromBinance()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetSuccessfulSellOrdersFromBinance()
    {
        throw new NotImplementedException();
    }

    public async Task<string> GetTickersFromBinance()
    {
        return await _binanceAdapter.GetTickers();
    }
}