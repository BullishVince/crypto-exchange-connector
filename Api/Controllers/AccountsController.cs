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
    public class AccountsController : ControllerBase
    {

        private readonly ILogger<AccountsController> _logger;
        private readonly IAccountService _accountService;

        public AccountsController(
            ILogger<AccountsController> logger, 
            IAccountService accountService
            )
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts() 
        {
            var result = await _accountService.GetAllAccounts();
            return Ok(result);
        }
    }
}
