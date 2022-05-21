using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using UnknownStore.BusinessLogic.CQRS.Commands.FactoryCommand;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.DAL.Entities.Store;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.UserCommands.CreateFavoriteItem
{
    public class CreateFavoriteModelHandler : IRequestHandler<CreateFavoriteModelCommand, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<CreateFavoriteModelHandler> _logger;

        public CreateFavoriteModelHandler
        (
            IStoreDbContext context,
            ILogger<CreateFavoriteModelHandler> logger
        )
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(CreateFavoriteModelCommand request, CancellationToken cancellationToken)
        {
            var dto = request.FavoriteModelDto;
            var user = await _context.Users.FindAsync(dto.UserId);
            user.FavoriteModels = new List<Model> { await _context.Models.FindAsync(dto.ModelId) };

            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(LoggerMessages.CommandExecutedSuccessfully(nameof(CreateFavoriteModelHandler)));
            return new CreateFactoryResponse { StatusCode = HttpStatusCode.Created };
        }
    }
}