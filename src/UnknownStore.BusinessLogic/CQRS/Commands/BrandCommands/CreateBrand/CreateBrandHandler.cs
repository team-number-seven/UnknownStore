using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.DAL.Entities.Store;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.BrandCommands.CreateBrand
{
    public class CreateBrandHandler : IRequestHandler<CreateBrandCommand, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<CreateBrandHandler> _logger;

        public CreateBrandHandler
        (
            IStoreDbContext context,
            ILogger<CreateBrandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var dto = request.BrandDto;
            var brand = new Brand { CountryId = dto.CountryId, Title = dto.Title };

            await _context.Brands.AddAsync(brand, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(LoggerMessages.CommandExecutedSuccessfully(nameof(CreateBrandHandler)));
            return new CreateBrandResponse { StatusCode = HttpStatusCode.Created };
        }
    }
}