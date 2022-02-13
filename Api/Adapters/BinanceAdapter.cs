using Api.Models.Binance;
using Binance.Spot;
using Binance.Spot.Models;
using Newtonsoft.Json;

namespace Api.Adapters
{
    public interface IBinanceAdapter {
        Task<string> GetFiatPaymentsHistory();
        Task<string> GetFiatDeposits();
        Task<SpotOrder[]> GetAllExecutedBuyOrders(string symbol);
        Task<string> GetAllExecutedSellOrders(string symbol);
        Task<string> GetTickers();
    }

    public class BinanceAdapter : IBinanceAdapter {
        private HttpClient _httpClient;
        private readonly Fiat _fiatClient;
        private readonly SpotAccountTrade _spotTradeClient;
        private readonly Market _marketClient;
        public BinanceAdapter(string apiKey, string apiSecret) {
            _httpClient = new HttpClient();
            _fiatClient = new Fiat(_httpClient, apiKey: apiKey, apiSecret: apiSecret);
            _spotTradeClient = new SpotAccountTrade(_httpClient, apiKey: apiKey, apiSecret: apiSecret);
            _marketClient = new Market(_httpClient, apiKey: apiKey, apiSecret: apiSecret);
        }

        public async Task<string> GetFiatPaymentsHistory() 
            => await _fiatClient.GetFiatPaymentsHistory(FiatPaymentTransactionType.BUY, beginTime: DateTime.Today.AddYears(-6).ToBinary());

        public async Task<string> GetFiatDeposits() 
            => await _fiatClient.GetFiatDepositWithdrawHistory(FiatOrderTransactionType.DEPOSIT, beginTime: DateTime.Today.AddYears(-6).ToBinary());

        public async Task<SpotOrder[]> GetAllExecutedBuyOrders(string symbol)
        {
            var orderList = new List<SpotOrder>();
            long startTime = (long)DateTime.Today.AddYears(-6).Subtract(DateTime.UnixEpoch).TotalSeconds;
            for (int i = 0; i < 3; i++) {
                var result = await _spotTradeClient.AllOrders(symbol.ToUpper(), limit: 1000, startTime: startTime);
                var orders = JsonConvert.DeserializeObject<SpotOrder[]>(result);
                orderList.AddRange(orders);
                startTime = (long)(DateTime.UnixEpoch.AddSeconds(startTime)).AddYears(2).Subtract(DateTime.UnixEpoch).TotalSeconds;
            }
            return orderList.Where(o => o.ExecutedQty > 0 && o.Side == "BUY").ToArray();
        }

        public Task<string> GetAllExecutedSellOrders(string symbol)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetTickers()
        {
            return await _marketClient.SymbolPriceTicker();
        }
    }
}