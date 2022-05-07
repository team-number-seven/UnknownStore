using MediatR;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects;

namespace UnknownStore.BusinessLogic.CQRS.Commands.Model.CreateModel
{
    public record CreateModelCommand(CreateModelDto CreateModelDto) : IRequest<ResponseBase>;
}
