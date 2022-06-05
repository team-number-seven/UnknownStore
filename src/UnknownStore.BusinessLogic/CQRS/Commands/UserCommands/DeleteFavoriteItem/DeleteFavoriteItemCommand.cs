using System;
using MediatR;
using UnknownStore.Common.CQRS;

namespace UnknownStore.BusinessLogic.CQRS.Commands.UserCommands.DeleteFavoriteItem
{
    public record DeleteFavoriteItemCommand(Guid UserId, Guid FavoriteItemId) : IRequest<ResponseBase>;
}