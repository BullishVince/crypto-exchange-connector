using Microsoft.AspNetCore.Mvc;
using Api.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CrossAccountingController : ControllerBase
    {

        private readonly ILogger<CrossAccountingController> _logger;
        private readonly IDepositService _depositService;
        private readonly IAccountService _accountService;
        private readonly IWithdrawalService _withdrawalService;
        private readonly ITradingService _tradingService;

        public CrossAccountingController(
            ILogger<CrossAccountingController> logger, 
            IDepositService depositService,
            IAccountService accountService,
            IWithdrawalService withdrawalService,
            ITradingService tradingService
            )
        {
            _logger = logger;
            _depositService = depositService;
            _accountService = accountService;
            _withdrawalService = withdrawalService;
            _tradingService = tradingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalAmountDeposited() 
        {
            var result = await _depositService.GetFiatPaymentsFromBinance();
            return Ok(result);
        } 

        [HttpGet]
        public async Task<IActionResult> GetSuccessfulBuyOrdersFromCoinbase(string accountId) 
        {
            var result = await _tradingService.GetSuccessfulBuyOrdersFromCoinbase(accountId);
            return Ok(result);
        }     

        [HttpGet]
        public async Task<IActionResult> GetSuccessfulSellOrdersFromCoinbase(string accountId) 
        {
            var result = await _tradingService.GetSuccessfulSellOrdersFromCoinbase(accountId);
            return Ok(result);
        }     
    }
}
