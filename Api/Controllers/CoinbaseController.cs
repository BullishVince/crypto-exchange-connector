using Microsoft.AspNetCore.Mvc;
using Api.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CoinbaseController : ControllerBase
    {

        private readonly ILogger<CoinbaseController> _logger;
        private readonly IDepositService _depositService;
        private readonly IAccountService _accountService;
        private readonly IWithdrawalService _withdrawalService;

        public CoinbaseController(
            ILogger<CoinbaseController> logger, 
            IDepositService depositService,
            IAccountService accountService,
            IWithdrawalService withdrawalService
            )
        {
            _logger = logger;
            _depositService = depositService;
            _accountService = accountService;
            _withdrawalService = withdrawalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts() 
        {
            var result = await _accountService.GetAllAccounts();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetDeposits(string accountId) 
        {
            var result = await _depositService.GetDepositsFromCoinbase(accountId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalAmountDeposited(string accountId) 
        {
            var result = await _depositService.GetTotalAmountDepositedToCoinbase(accountId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithdrawals(string accountId) 
        {
            var result = await _withdrawalService.GetWithdrawals(accountId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalAmountWithdrawed(string accountId) 
        {
            var result = await _withdrawalService.GetTotalAmountWithdrawed(accountId);
            return Ok(result);
        } 
    }
}
