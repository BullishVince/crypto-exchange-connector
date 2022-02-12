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
        private readonly ITradingService _tradingService;

        public BinanceController(
            ILogger<BinanceController> logger, 
            IDepositService depositService,
            ITradingService tradingService
            )
        {
            _logger = logger;
            _depositService = depositService;
            _tradingService = tradingService;
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

        [HttpGet]
        public async Task<IActionResult> GetTickers() 
        {
            var result = await _tradingService.GetTickersFromBinance();
            return Ok(result);
        }         
    }
}
