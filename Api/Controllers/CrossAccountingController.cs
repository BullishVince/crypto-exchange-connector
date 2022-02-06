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

        public CrossAccountingController(
            ILogger<CrossAccountingController> logger, 
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
        public async Task<IActionResult> GetTotalAmountDeposited() 
        {
            var result = await _depositService.GetFiatPaymentsFromBinance();
            return Ok(result);
        }      
    }
}
