using Api.Adapters;
using Api.Messages;
using Coinbase.Models;

namespace Api.Services {
    public interface IAccountService {
        public Task<Account[]> GetAllAccounts();
    }
    public class AccountService : IAccountService {
        private ICoinbaseAdapter _adapter { get; set; }
        public AccountService(ICoinbaseAdapter adapter) {
            _adapter = adapter;
        }
        public async Task<Account[]> GetAllAccounts() => await _adapter.GetAllAccounts();
    }
}