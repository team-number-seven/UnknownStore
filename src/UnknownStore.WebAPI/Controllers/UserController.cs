using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.BusinessLogic.CQRS.Commands.UserCommands.CreateFavoriteItem;
using UnknownStore.BusinessLogic.CQRS.Queries.UserQueries.GetFavoriteModels;
using UnknownStore.Common.Constants;
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

        [Authorize(Policy = nameof(Roles.User))]
        [HttpGet]
        [Route("get-favorites")]
        public async Task<IActionResult> GetAllFavoriteModels([FromQuery] Guid userId)
        {
            Guid.TryParse(User!.FindFirstValue("id"), out var id);
            if (id != userId) return StatusCode(StatusCodes.Status400BadRequest, new { error = "Invalid userId" });

            var response = await _mediator.Send(new GetFavoriteModelsQuery(userId));
            return StatusCode((int)response.StatusCode, response);
        }
    }
}