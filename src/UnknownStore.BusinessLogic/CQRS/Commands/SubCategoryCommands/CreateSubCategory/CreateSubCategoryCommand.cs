using MediatR;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Create;

namespace UnknownStore.BusinessLogic.CQRS.Commands.SubCategoryCommands.CreateSubCategory
{
    public record CreateSubCategoryCommand(CreateSubCategoryDto SubCategoryDto) : IRequest<ResponseBase>;
}