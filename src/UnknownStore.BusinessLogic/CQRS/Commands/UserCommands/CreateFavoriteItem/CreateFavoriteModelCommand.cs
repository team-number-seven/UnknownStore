using MediatR;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Create;

namespace UnknownStore.BusinessLogic.CQRS.Commands.UserCommands.CreateFavoriteItem
{
    public record CreateFavoriteModelCommand(CreateFavoriteModelDto FavoriteModelDto) : IRequest<ResponseBase>;
}