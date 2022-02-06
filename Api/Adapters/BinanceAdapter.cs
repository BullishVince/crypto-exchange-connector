using Binance.Spot;
using Binance.Spot.Models;

namespace Api.Adapters
{
    public interface IBinanceAdapter {
        Task<string> GetFiatPaymentsHistory();
        Task<string> GetFiatDeposits();
    }

    public class BinanceAdapter : IBinanceAdapter {
        private HttpClient _httpClient;
        private readonly Fiat _fiatClient;

        public BinanceAdapter(string apiKey, string apiSecret) {
            _httpClient = new HttpClient();
            _fiatClient = new Fiat(_httpClient, apiKey: apiKey, apiSecret: apiSecret);
        }

        public async Task<string> GetFiatPaymentsHistory() 
            => await _fiatClient.GetFiatPaymentsHistory(FiatPaymentTransactionType.BUY, beginTime: DateTime.Today.AddYears(6).ToBinary());

        public async Task<string> GetFiatDeposits() 
            => await _fiatClient.GetFiatDepositWithdrawHistory(FiatOrderTransactionType.DEPOSIT, beginTime: DateTime.Today.AddYears(6).ToBinary());
    }
}