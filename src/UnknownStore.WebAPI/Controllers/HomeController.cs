using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UnknownStore.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController:ControllerBase
    {
        public HomeController()
        {
            
        }

        [Authorize(Policy = "Owner")]
        [Route("[action]")]
        [HttpGet]
        public IActionResult Test()
        {
            var t = new Tests();
            return Ok(t);
        }
    }

    public class Tests
    {
        public string test { get; set; } = "test";
    }

}

