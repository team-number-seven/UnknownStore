using MediatR;
using UnknownStore.Common.CQRS;

namespace UnknownStore.BusinessLogic.CQRS.Queries.CategoryQueries.GetAllCategories
{
    public record GetAllCategoriesQuery : IRequest<ResponseBase>;
}