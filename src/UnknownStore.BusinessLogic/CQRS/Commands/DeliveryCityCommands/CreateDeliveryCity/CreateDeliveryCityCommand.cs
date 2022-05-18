using MediatR;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Create;

namespace UnknownStore.BusinessLogic.CQRS.Commands.DeliveryCityCommands.CreateDeliveryCity
{
    public record CreateDeliveryCityCommand(CreateDeliveryCityDto DeliveryCityDto) : IRequest<ResponseBase>;
}