using Api.Adapters;
using Api.Messages;
using Coinbase.Models;
using Newtonsoft.Json;

namespace Api.Services {
    public interface IDepositService {
        public Task<Deposit[]> GetDeposits(string accountId);
        public Task<decimal> GetTotalAmountDeposited(string accountId);
        public Task<string> GetPurchasesFromBinance();
    }
    public class DepositService : IDepositService {
        private ICoinbaseAdapter _coinbaseAdapter { get; set; }
        private IBinanceAdapter _binanceAdapter { get; set; }
        public DepositService(ICoinbaseAdapter coinhbaseAdapter, IBinanceAdapter binanceAdapter) {
            _coinbaseAdapter = coinhbaseAdapter;
            _binanceAdapter = binanceAdapter;
        }
        public async Task<Deposit[]> GetDeposits(string accountId) => await _coinbaseAdapter.GetDeposits(accountId);
        public async Task<decimal> GetTotalAmountDeposited(string accountId) {
            decimal amount = 0;
            var deposits = await _coinbaseAdapter.GetDeposits(accountId);
            foreach (Deposit deposit in deposits) {
                amount += deposit.Amount.Amount;
            }
            return amount;
        }

        public async Task<string> GetPurchasesFromBinance() => await _binanceAdapter.GetPurchases();
        public async Task<decimal> GetTotalPurchaseAmountFromBinance() {
            decimal amount = 0;
            var json = await _binanceAdapter.GetPurchases();
            /*var purchases = JsonConvert.DeserializeObject<Purchase
            foreach (string purchase in purchases) {
                amount += deposit.Amount.Amount;
            }*/
            return amount;
        }

        public class Purchase {
            /*
            "orderNo": "a6a581de0cce43479c8d00c97946f05f",
            "sourceAmount": "168.64",
            "fiatCurrency": "SEK",
            "obtainAmount": "19.59194835",
            "cryptoCurrency": "BUSD",
            "totalFee": "3.37",
            "price": "8.43560819",
            "status": "Completed",
            "createTime": 1613741519000,
            "updateTime": 1613741542000
            */
            public long SourceAmount { get; set; }
            public string FiatCurrency { get; set; }
            public string CryptoCurrency { get; set; }
            public long TotalFee { get; set; }
            public int Price { get; set; }
        }

    }
}