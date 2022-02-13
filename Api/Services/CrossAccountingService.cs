using Api.Adapters;
using Api.Models.Binance;
using Coinbase.Models;
using Newtonsoft.Json;

namespace Api.Services
{
    public interface ICrossAccountingService {
        public Task<string> GetAllFiatDeposits();
        public Task<string> GetAllFiatWithdrawals();
        public Task<string> GetAllExecutedBuyOrders();
        public Task<string> GetAllExecutedSellOrders();
        public Task<string> GetAllExecutedOrders();

    }
    public class CrossAccountingService : ICrossAccountingService {
        private ICoinbaseAdapter _coinbaseAdapter { get; set; }
        private IBinanceAdapter _binanceAdapter { get; set; }
        public CrossAccountingService(ICoinbaseAdapter coinbaseAdapter, IBinanceAdapter binanceAdapter) {
            _coinbaseAdapter = coinbaseAdapter;
            _binanceAdapter = binanceAdapter;
        }

        public Task<string> GetAllFiatDeposits()
        {
            var fiatDeposits = new Deposit();
            throw new NotImplementedException();
        }

        public Task<string> GetAllFiatWithdrawals()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAllExecutedBuyOrders()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAllExecutedSellOrders()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetAllExecutedOrders()
        {
            var coinbaseOrders = new List<Buy>();
            var coinbaseAccounts = await _coinbaseAdapter.GetAllAccounts();
            coinbaseAccounts = coinbaseAccounts.Where(a => !a.Id.Contains("UPI") && !a.Id.Contains("LOOM")).ToArray();
            foreach (Account account in coinbaseAccounts) {
                var buyOrders = await _coinbaseAdapter.GetCompletedBuyOrders(account.Id);
                var sellOrders = JsonConvert.SerializeObject(await _coinbaseAdapter.GetCompletedSellOrders(account.Id));
                coinbaseOrders.AddRange(buyOrders);
                coinbaseOrders.AddRange(JsonConvert.DeserializeObject<Buy[]>(sellOrders));
            }
            return JsonConvert.SerializeObject(coinbaseOrders);
        }
    }
}