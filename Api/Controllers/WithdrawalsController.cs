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
    [Route("[controller]/[action]")]
    public class WithdrawalsController : ControllerBase
    {

        private readonly ILogger<WithdrawalsController> _logger;
        private readonly IWithdrawalService _withdrawalService;

        public WithdrawalsController(
            ILogger<WithdrawalsController> logger, 
            IWithdrawalService withdrawalService
            )
        {
            _logger = logger;
            _withdrawalService = withdrawalService;
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
