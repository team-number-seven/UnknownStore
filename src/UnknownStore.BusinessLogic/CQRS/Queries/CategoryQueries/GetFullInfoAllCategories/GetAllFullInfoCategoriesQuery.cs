using MediatR;
using UnknownStore.Common.CQRS;

namespace UnknownStore.BusinessLogic.CQRS.Queries.CategoryQueries.GetFullInfoAllCategories
{
    public record GetAllFullInfoCategoriesQuery : IRequest<ResponseBase>;
}