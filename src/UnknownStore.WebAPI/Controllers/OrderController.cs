using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.BusinessLogic.CQRS.Commands.OrderCommands.CreateOrder;
using UnknownStore.BusinessLogic.CQRS.Commands.OrderCommands.UpdateOrderStatus;
using UnknownStore.Common.DataTransferObjects.Create;
using UnknownStore.Common.DataTransferObjects.Update;

namespace UnknownStore.WebAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("store/order")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(
            IMediator mediator
        )
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("add-order")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto request)
        {
            var response = await _mediator.Send(new CreateOrderCommand(request));
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut]
        [Route("set-status-order")]
        public async Task<IActionResult> UpdateOrderStatus([FromQuery] UpdateOrderStatusDto request)
        {
            var response = await _mediator.Send(new UpdateOrderStatusCommand(request));
            return StatusCode((int)response.StatusCode, response);
        }
    }
}