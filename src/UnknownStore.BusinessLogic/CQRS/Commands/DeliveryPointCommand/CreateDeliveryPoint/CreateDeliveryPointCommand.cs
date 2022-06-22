using MediatR;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Create;

namespace UnknownStore.BusinessLogic.CQRS.Commands.DeliveryPointCommand.CreateDeliveryPoint
{
    public record CreateDeliveryPointCommand(CreateDeliveryPointDto Dto) : IRequest<ResponseBase>;
}