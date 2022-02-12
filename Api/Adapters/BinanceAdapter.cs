using Binance.Spot;
using Binance.Spot.Models;

namespace Api.Adapters
{
    public interface IBinanceAdapter {
        Task<string> GetFiatPaymentsHistory();
        Task<string> GetFiatDeposits();
        Task<string> GetAllExecutedBuyOrders();
        Task<string> GetAllExecutedSellOrders();
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
            => await _fiatClient.GetFiatPaymentsHistory(FiatPaymentTransactionType.BUY, beginTime: DateTime.Today.AddYears(6).ToBinary());

        public async Task<string> GetFiatDeposits() 
            => await _fiatClient.GetFiatDepositWithdrawHistory(FiatOrderTransactionType.DEPOSIT, beginTime: DateTime.Today.AddYears(6).ToBinary());

        public async Task<string> GetAllExecutedBuyOrders()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAllExecutedSellOrders()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetTickers()
        {
            return await _marketClient.SymbolPriceTicker();
        }
    }
}