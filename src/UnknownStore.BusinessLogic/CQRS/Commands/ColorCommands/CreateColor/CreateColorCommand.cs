using MediatR;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Create;

namespace UnknownStore.BusinessLogic.CQRS.Commands.ColorCommands.CreateColor
{
    public record CreateColorCommand(CreateColorDto ColorDto) : IRequest<ResponseBase>;
}