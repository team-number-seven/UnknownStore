using MediatR;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Get;

namespace UnknownStore.BusinessLogic.CQRS.Queries.ModelQueries.GetViewModelsByFilter
{
    public record GetViewModelsByFilterQuery(GetViewModelFilterDto Filter) : IRequest<ResponseBase>;
}