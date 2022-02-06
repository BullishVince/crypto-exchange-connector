using Microsoft.AspNetCore.Mvc;
using Api.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BinanceController : ControllerBase
    {

        private readonly ILogger<BinanceController> _logger;
        private readonly IDepositService _depositService;

        public BinanceController(
            ILogger<BinanceController> logger, 
            IDepositService depositService
            )
        {
            _logger = logger;
            _depositService = depositService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFiatPayments() 
        {
            var result = await _depositService.GetFiatPaymentsFromBinance();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalFiatPaymentsAmount() 
        {
            var result = await _depositService.GetTotalFiatPaymentsAmountFromBinance();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetFiatDeposits() 
        {
            var result = await _depositService.GetFiatDepositsFromBinance();
            return Ok(result);
        }      
    }
}
