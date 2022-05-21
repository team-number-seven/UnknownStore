using MediatR;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Create;

namespace UnknownStore.BusinessLogic.CQRS.Commands.CategoryCommands.CreateCategory
{
    public record CreateCategoryCommand(CreateCategoryDto CategoryDto) : IRequest<ResponseBase>;
}