using MediatR;
using UnknownStore.Common.CQRS;

namespace UnknownStore.BusinessLogic.CQRS.Queries.AgeTypeQueries.GetAllAgeTypes
{
    public record GetAllAgeTypesQuery : IRequest<ResponseBase>;
}