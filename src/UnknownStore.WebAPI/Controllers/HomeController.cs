using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnknownStore.BusinessLogic.CQRS.Commands.ModelCommands.CreateModel;
using UnknownStore.Common.DataTransferObjects.Create;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator, IStoreDbContext context)
        {
            _logger = logger;
            _mediator = mediator;
            _context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Test([FromForm] CreateModelDto request)
        {
            var response = await _mediator.Send(new CreateModelCommand(request));
            return StatusCode((int)response.StatusCode, response);
        }
    }

    public class Tests
    {
        public string test { get; set; } = "test";
    }
}