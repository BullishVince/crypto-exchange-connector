using System.Threading.Tasks;
using Coinbase;
using Coinbase.Models;

namespace Api.Adapters {
    public interface ICoinbaseAdapter {
        Task<Deposit[]> GetDeposits(string accountId);
        Task<Withdrawal[]> GetWithdrawals(string accountId);
        Task<Account[]> GetAllAccounts();
    }

    public class CoinbaseAdapter : ICoinbaseAdapter {
        private readonly CoinbaseClient _client;

        public CoinbaseAdapter(string apiKey, string apiSecret) {
            _client = new CoinbaseClient(new ApiKeyConfig{ ApiKey = apiKey, ApiSecret = apiSecret});
        }

        public async Task<Deposit[]> GetDeposits(string accountId)
        {
            var deposits = await _client.Deposits.ListDepositsAsync(accountId);
            return deposits.Data;
        }

        public async Task<Withdrawal[]> GetWithdrawals(string accountId)
        {
            var withdrawals = await _client.Withdrawals.ListWithdrawalsAsync(accountId);
            return withdrawals.Data;
        }

        public async Task<Account[]> GetAllAccounts() {
            var accounts  = await _client.Accounts.ListAccountsAsync();
            return accounts.Data;
        }


        public class BinanceResponseObject {
            
        }
    }
}