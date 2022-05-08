using MediatR;
using UnknownStore.Common.CQRS;

namespace UnknownStore.BusinessLogic.CQRS.Queries.FactoryQueries.GetAllFactories
{
    public record GetAllFactoriesQuery : IRequest<ResponseBase>;
}