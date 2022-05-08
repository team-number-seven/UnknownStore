using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.BusinessLogic.CQRS.Queries.ColorQueries.GetAllColors;

namespace UnknownStore.WebAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("store/[controller]")]
    public class ColorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ColorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllColors()
        {
            var response = await _mediator.Send(new GetAllColorsQuery());
            return StatusCode((int)response.StatusCode, response);
        }
    }
}