using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.BusinessLogic.CQRS.Commands.ModelCommands.CreateModel;
using UnknownStore.BusinessLogic.CQRS.Queries.ModelQueries.GetModelById;
using UnknownStore.BusinessLogic.CQRS.Queries.ModelQueries.GetViewModelsByFilter;
using UnknownStore.Common.Constants;
using UnknownStore.Common.DataTransferObjects.Create;
using UnknownStore.Common.DataTransferObjects.Get;

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

        [HttpGet]
        [Route("get-models")]
        public async Task<IActionResult> GetViewModels([FromQuery] GetViewModelFilterDto request)
        {
            var response = await _mediator.Send(new GetViewModelsByFilterQuery(request));
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetModelById([FromQuery] Guid id)
        {
            var response = await _mediator.Send(new GetModelByIdQuery(id));
            return StatusCode((int)response.StatusCode, response);
        }
    }
}