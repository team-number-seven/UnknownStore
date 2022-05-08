using MediatR;
using UnknownStore.Common.CQRS;

namespace UnknownStore.BusinessLogic.CQRS.Queries.SeasonQueries.GetAllSeasons
{
    public record GetAllSeasonsQuery : IRequest<ResponseBase>;
}