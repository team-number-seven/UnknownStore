using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.BusinessLogic.CQRS.Commands.ModelCommands.CreateModel;
using UnknownStore.Common.Constants;
using UnknownStore.Common.DataTransferObjects;

namespace UnknownStore.WebAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("store/[controller]")]
    public class ModelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ModelController(
            IMediator mediator
        )
        {
            _mediator = mediator;
        }

        [Authorize(Policy = nameof(Roles.Manager))]
        [HttpPost]
        [Route("add-model")]
        public async Task<IActionResult> CreateModel([FromForm] CreateModelDto request)
        {
            var response = await _mediator.Send(new CreateModelCommand(request));
            return StatusCode((int)response.StatusCode, response);
        }
    }
}