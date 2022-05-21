using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.BusinessLogic.CQRS.Commands.UserCommands.CreateFavoriteItem;
using UnknownStore.Common.DataTransferObjects.Create;

namespace UnknownStore.WebAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("store/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(
            IMediator mediator
        )
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("add-favorite")]
        public async Task<IActionResult> CreateFavoriteModel([FromBody] CreateFavoriteModelDto request)
        {
            var response = await _mediator.Send(new CreateFavoriteModelCommand(request));
            return StatusCode((int)response.StatusCode, response);
        }
    }
}