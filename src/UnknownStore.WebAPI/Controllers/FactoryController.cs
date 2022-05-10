using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.BusinessLogic.CQRS.Commands.FactoryCommand;
using UnknownStore.BusinessLogic.CQRS.Queries.FactoryQueries.GetAllFactories;
using UnknownStore.Common.DataTransferObjects.Create;

namespace UnknownStore.WebAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("store/[controller]")]
    public class FactoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FactoryController(
            IMediator mediator
        )
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllFactories()
        {
            var response = await _mediator.Send(new GetAllFactoriesQuery());
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        [Route("add-factory")]
        public async Task<IActionResult> CreateFactory([FromBody] CreateFactoryDto request)
        {
            var response = await _mediator.Send(new CreateFactoryCommand(request));
            return StatusCode((int)response.StatusCode, response);
        }
    }
}