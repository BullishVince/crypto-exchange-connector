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
        public async Task<IActionResult> GetAllDeposits(string accountId) 
        {
            var result = await _depositService.GetDeposits(accountId);
            return Ok(result);
        }

        [HttpGet("Coinbase/[action]")]
        public async Task<IActionResult> GetTotalAmountDeposited(string accountId) 
        {
            var result = await _depositService.GetTotalAmountDeposited(accountId);
            return Ok(result);
        }

        [HttpGet("Binance/[action]")]
        public async Task<IActionResult> GetPurchases() 
        {
            var result = await _depositService.GetPurchasesFromBinance();
            return Ok(result);
        }
    }
}
