using Microsoft.AspNetCore.Mvc;
using Api.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LocalDataController : ControllerBase
    {

        private readonly ILogger<LocalDataController> _logger;
        private readonly IDataService _dataService;

        public LocalDataController(
            ILogger<LocalDataController> logger, 
            IDataService dataService
            )
        {
            _logger = logger;
            _dataService = dataService;
        } 

        [HttpGet]
        public async Task<IActionResult> GetCachedTickers()
        {
            var result = await _dataService.GetCachedTickers();
            return Ok(result);
        }         
    }
}
