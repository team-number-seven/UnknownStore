using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.BusinessLogic.CQRS.Commands.DeliveryPointCommand.CreateDeliveryPoint;
using UnknownStore.Common.DataTransferObjects.Create;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.WebAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("store/[controller]")]
    public class DeliveryPointController:ControllerBase
    {
        private readonly IMediator _mediator;

        public DeliveryPointController(
            IMediator mediator
        )
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("add-point")]
        public async Task<IActionResult> CreatePoint([FromBody] CreateDeliveryPointDto request)
        {
            var response = await _mediator.Send(new CreateDeliveryPointCommand(request));
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
