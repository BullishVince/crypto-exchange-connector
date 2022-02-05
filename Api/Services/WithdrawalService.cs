using Api.Adapters;
using Api.Messages;
using Coinbase.Models;

namespace Api.Services {
    public interface IWithdrawalService {
        public Task<Withdrawal[]> GetWithdrawals(string accountId);
        public Task<decimal> GetTotalAmountWithdrawed(string accountId);
    }
    public class WithdrawalService : IWithdrawalService {
        private ICoinbaseAdapter _adapter { get; set; }
        public WithdrawalService(ICoinbaseAdapter adapter) {
            _adapter = adapter;
        }
        public async Task<Withdrawal[]> GetWithdrawals(string accountId) => await _adapter.GetWithdrawals(accountId);
        public async Task<decimal> GetTotalAmountWithdrawed(string accountId) {
            decimal amount = 0;
            var withdrawals = await _adapter.GetWithdrawals(accountId);
            foreach (Withdrawal withdrawal in withdrawals) {
                amount += withdrawal.Amount.Amount;
            }
            return amount;
        }
    }
}