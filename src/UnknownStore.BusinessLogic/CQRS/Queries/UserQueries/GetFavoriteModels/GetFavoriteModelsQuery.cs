using System;
using MediatR;
using UnknownStore.Common.CQRS;

namespace UnknownStore.BusinessLogic.CQRS.Queries.UserQueries.GetFavoriteModels
{
    public record GetFavoriteModelsQuery(Guid UserId) : IRequest<ResponseBase>;
}