using MediatR;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Create;

namespace UnknownStore.BusinessLogic.CQRS.Commands.BrandCommands.CreateBrand
{
    public record CreateBrandCommand(CreateBrandDto BrandDto) : IRequest<ResponseBase>;
}
