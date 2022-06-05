using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.UserCommands.DeleteFavoriteItem
{
    public class DeleteFavoriteItemHandler : IRequestHandler<DeleteFavoriteItemCommand, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<DeleteFavoriteItemHandler> _logger;

        public DeleteFavoriteItemHandler
        (
            IStoreDbContext context,
            ILogger<DeleteFavoriteItemHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(DeleteFavoriteItemCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            var favoriteModel = user.FavoriteModels.First(m => m.Id == request.FavoriteItemId);
            var listModels = user.FavoriteModels.ToList();
            listModels.Remove(favoriteModel);
            user.FavoriteModels = listModels;

            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation(LoggerMessages.CommandExecutedSuccessfully(nameof(DeleteFavoriteItemHandler)));
            return new DeleteFavoriteItemResponse();
        }
    }
}