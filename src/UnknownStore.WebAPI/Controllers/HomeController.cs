using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UnknownStore.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController:ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize(Policy = "Owner")]
        [Route("[action]")]
        [HttpGet]
        public IActionResult Test()
        {
            _logger.LogInformation(User.FindFirstValue("Id"));
            var t = new Tests();
            return Ok(t);
        }
    }

    public class Tests
    {
        public string test { get; set; } = "test";
    }

}

