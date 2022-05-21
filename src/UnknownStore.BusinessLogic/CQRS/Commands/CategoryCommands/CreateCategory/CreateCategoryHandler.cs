using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.DAL.Entities.Store;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<CreateCategoryHandler> _logger;

        public CreateCategoryHandler
        (
            IStoreDbContext context,
            ILogger<CreateCategoryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var dto = request.CategoryDto;
            var category = new Category { AgeTypeId = dto.AgeTypeId, Title = dto.Title, GenderId = dto.GenderId };

            await _context.Categories.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(LoggerMessages.CommandExecutedSuccessfully(nameof(CreateCategoryHandler)));
            return new CreateCategoryResponse { StatusCode = HttpStatusCode.Created };
        }
    }
}