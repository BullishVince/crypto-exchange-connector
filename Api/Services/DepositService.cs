using Api.Adapters;
using Api.Messages;
using Api.Models.Binance;
using Coinbase.Models;
using Newtonsoft.Json;

namespace Api.Services {
    public interface IDepositService {
        public Task<Deposit[]> GetDepositsFromCoinbase(string accountId);
        public Task<decimal> GetTotalAmountDepositedToCoinbase(string accountId);
        public Task<string> GetFiatPaymentsFromBinance();
        public Task<decimal> GetTotalFiatPaymentsAmountFromBinance();
    }
    public class DepositService : IDepositService {
        private ICoinbaseAdapter _coinbaseAdapter { get; set; }
        private IBinanceAdapter _binanceAdapter { get; set; }
        public DepositService(ICoinbaseAdapter coinhbaseAdapter, IBinanceAdapter binanceAdapter) {
            _coinbaseAdapter = coinhbaseAdapter;
            _binanceAdapter = binanceAdapter;
        }
        public async Task<Deposit[]> GetDepositsFromCoinbase(string accountId) => await _coinbaseAdapter.GetDeposits(accountId);
        public async Task<decimal> GetTotalAmountDepositedToCoinbase(string accountId) {
            decimal amount = 0;
            var deposits = await _coinbaseAdapter.GetDeposits(accountId);
            foreach (Deposit deposit in deposits) {
                amount += deposit.Amount.Amount;
            }
            return amount;
        }

        public async Task<string> GetFiatPaymentsFromBinance() => await _binanceAdapter.GetFiatPaymentsHistory();
        public async Task<decimal> GetTotalFiatPaymentsAmountFromBinance() {
            decimal amount = 0;
            var json = await _binanceAdapter.GetFiatPaymentsHistory();
            var purchases = JsonConvert.DeserializeObject<FiatPayments>(json);
            foreach (Purchase purchase in purchases.Data) {
                amount += purchase.SourceAmount;
            }
            return amount;
        }
    }
}