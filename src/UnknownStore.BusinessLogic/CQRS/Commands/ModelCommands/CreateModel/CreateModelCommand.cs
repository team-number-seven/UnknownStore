using MediatR;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects;

namespace UnknownStore.BusinessLogic.CQRS.Commands.ModelCommands.CreateModel
{
    public record CreateModelCommand(CreateModelDto CreateModelDto) : IRequest<ResponseBase>;
}