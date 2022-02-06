using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api.Services;
using Api.Messages;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepositsController : ControllerBase
    {

        private readonly ILogger<DepositsController> _logger;
        private readonly IDepositService _depositService;

        public DepositsController(
            ILogger<DepositsController> logger, 
            IDepositService depositService
            )
        {
            _logger = logger;
            _depositService = depositService;
        }

        [HttpGet("Coinbase/[action]")]
        public async Task<IActionResult> GetDepositsFromCoinbase(string accountId) 
        {
            var result = await _depositService.GetDepositsFromCoinbase(accountId);
            return Ok(result);
        }

        [HttpGet("Coinbase/[action]")]
        public async Task<IActionResult> GetTotalAmountDepositedToCoinbase(string accountId) 
        {
            var result = await _depositService.GetTotalAmountDepositedToCoinbase(accountId);
            return Ok(result);
        }

        [HttpGet("Binance/[action]")]
        public async Task<IActionResult> GetAllFiatPayments() 
        {
            var result = await _depositService.GetFiatPaymentsFromBinance();
            return Ok(result);
        }

        [HttpGet("Binance/[action]")]
        public async Task<IActionResult> GetTotalFiatPaymentsAmount() 
        {
            var result = await _depositService.GetTotalFiatPaymentsAmountFromBinance();
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTotalAmountDeposited([FromQuery] string fiatCurrency) 
        {
            var result = await _depositService.GetTotalFiatPaymentsAmountFromBinance();
            return Ok(result);
        }        
    }
}
