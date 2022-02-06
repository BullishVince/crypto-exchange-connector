using System.Threading.Tasks;
using Coinbase;
using Coinbase.Models;

namespace Api.Adapters {
    public interface ICoinbaseAdapter {
        Task<Deposit[]> GetDeposits(string accountId);
        Task<Withdrawal[]> GetWithdrawals(string accountId);
        Task<Account[]> GetAllAccounts();
        Task<Buy[]> GetPurchases(string accountId);
        Task<Transaction> GetTransaction(string accountId, string transactionId);
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

        public async Task<Buy[]> GetPurchases(string accountId) {
            var buys  = await _client.Buys.ListBuysAsync(accountId);
            return buys.Data;
        }

        public async Task<Transaction> GetTransaction(string accountId, string transactionId) {
            var transaction  = await _client.Transactions.GetTransactionAsync(accountId, transactionId);
            return transaction.Data;
        }
    }
}