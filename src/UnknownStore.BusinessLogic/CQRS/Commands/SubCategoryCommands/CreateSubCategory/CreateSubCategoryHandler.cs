using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.DAL.Entities.Store;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.SubCategoryCommands.CreateSubCategory
{
    public class CreateSubCategoryHandler : IRequestHandler<CreateSubCategoryCommand, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<CreateSubCategoryHandler> _logger;

        public CreateSubCategoryHandler
        (
            IStoreDbContext context,
            ILogger<CreateSubCategoryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var dto = request.SubCategoryDto;
            var size = new Size { MinValue = dto.Size.MinValue, MaxValue = dto.Size.MaxValue };
            var subCategory = new SubCategory { CategoryId = dto.CategoryId, Title = dto.Title, Size = size };

            await _context.SubCategories.AddAsync(subCategory, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(LoggerMessages.CommandExecutedSuccessfully(nameof(CreateSubCategoryHandler)));
            return new CreateSubCategoryResponse { StatusCode = HttpStatusCode.Created };
        }
    }
}