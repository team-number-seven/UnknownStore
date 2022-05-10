using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.BusinessLogic.CQRS.Queries.AgeTypeQueries.GetAllAgeTypes;

namespace UnknownStore.WebAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("store/age-type")]
    public class AgeTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AgeTypeController(
            IMediator mediator
        )
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllAgeTypes()
        {
            var response = await _mediator.Send(new GetAllAgeTypesQuery());
            return StatusCode((int)response.StatusCode, response);
        }
    }
}