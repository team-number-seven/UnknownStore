using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.BusinessLogic.CQRS.Queries.FactoryQueries.GetAllFactories;

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
    }
}