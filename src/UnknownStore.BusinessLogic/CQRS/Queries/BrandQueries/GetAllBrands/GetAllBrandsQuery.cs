using MediatR;
using UnknownStore.Common.CQRS;

namespace UnknownStore.BusinessLogic.CQRS.Queries.BrandQueries.GetAllBrands
{
    public record GetAllBrandsQuery : IRequest<ResponseBase>;
}