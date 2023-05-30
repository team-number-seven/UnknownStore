using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.BusinessLogic.CQRS.Queries.GenderQueries.GetAllGenders;

namespace UnknownStore.WebAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("store/[controller]")]
    public class GenderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenderController(
            IMediator mediator
        )
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllGenders()
        {
            var response = await _mediator.Send(new GetAllGendersQuery());
            return StatusCode((int)response.StatusCode, response);
        }
    }
}