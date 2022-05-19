using MediatR;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Update;

namespace UnknownStore.BusinessLogic.CQRS.Commands.OrderCommands.UpdateOrderStatus
{
    public record UpdateOrderStatusCommand(UpdateOrderStatusDto UpdateOrderStatusDto) : IRequest<ResponseBase>;
}