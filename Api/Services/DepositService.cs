using Api.Adapters;
using Api.Models.Binance;
using Coinbase.Models;
using Newtonsoft.Json;

namespace Api.Services
{
    public interface IDepositService {
        public Task<Deposit[]> GetDepositsFromCoinbase(string accountId);
        public Task<decimal> GetTotalAmountDepositedToCoinbase(string accountId);
        public Task<Buy[]> GetPurchasesFromCoinbase(string accountId);
        public Task<decimal> GetTotalPurchaseAmountFromCoinbase(string accountId);
        public Task<Transaction> GetTransactionFromCoinbase(string accountId, string transactionId);

        public Task<string> GetFiatPaymentsFromBinance();
        public Task<string> GetFiatDepositsFromBinance();
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
        public async Task<string> GetFiatDepositsFromBinance() => await _binanceAdapter.GetFiatDeposits();
        public async Task<decimal> GetTotalFiatPaymentsAmountFromBinance() {
            decimal amount = 0;
            var json = await _binanceAdapter.GetFiatPaymentsHistory();
            var purchases = JsonConvert.DeserializeObject<FiatPayments>(json);
            foreach (Purchase purchase in purchases.Data) {
                amount += purchase.SourceAmount;
            }
            return amount;
        }

        public async Task<Buy[]> GetPurchasesFromCoinbase(string accountId) => await _coinbaseAdapter.GetPurchases(accountId);
        public async Task<decimal> GetTotalPurchaseAmountFromCoinbase(string accountId) {
            decimal amount = 0;
            var purchases = await _coinbaseAdapter.GetPurchases(accountId);
            foreach (Buy purchase in purchases) {
                amount += purchase.Total.Amount;
            }
            return amount;
        }

        public async Task<Transaction> GetTransactionFromCoinbase(string accountId, string transactionId) {
            var transaction = await _coinbaseAdapter.GetTransaction(accountId, transactionId);
            return transaction;
        }
    }
}