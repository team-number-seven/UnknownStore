using MediatR;
using UnknownStore.Common.CQRS;

namespace UnknownStore.BusinessLogic.CQRS.Queries.GenderQueries.GetAllGenders
{
    public record GetAllGendersQuery : IRequest<ResponseBase>;
}