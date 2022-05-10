using MediatR;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Create;

namespace UnknownStore.BusinessLogic.CQRS.Commands.FactoryCommand
{
    public record CreateFactoryCommand(CreateFactoryDto CreateFactoryDto) : IRequest<ResponseBase>;
}