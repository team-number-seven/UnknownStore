using MediatR;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Create;

namespace UnknownStore.BusinessLogic.CQRS.Commands.OrderCommands.CreateOrder
{
    public record CreateOrderCommand(CreateOrderDto OrderDto) : IRequest<ResponseBase>;
}