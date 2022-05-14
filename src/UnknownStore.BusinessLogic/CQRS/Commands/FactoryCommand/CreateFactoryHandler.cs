using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.DAL.Entities.Store;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.FactoryCommand
{
    public class CreateFactoryHandler : IRequestHandler<CreateFactoryCommand, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<CreateFactoryHandler> _logger;

        public CreateFactoryHandler(
            IStoreDbContext context,
            ILogger<CreateFactoryHandler> logger
        )
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(CreateFactoryCommand request, CancellationToken cancellationToken)
        {
            var dto = request.CreateFactoryDto;
            var country = await _context.Countries.FindAsync(dto.CountryId);
            var address = new Address
            {
                AddressLine = dto.AddressLine,
                Country = await _context.Countries.FindAsync(dto.CountryId),
                City = await _context.Cities.FindAsync(dto.CityId)
            };
            var factory = new Factory { Address = address, Title = dto.Title };

            await _context.Factories.AddAsync(factory, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(LoggerMessages.CommandExecutedSuccessfully(nameof(CreateFactoryHandler)));
            return new CreateFactoryResponse { StatusCode = HttpStatusCode.Created };
        }
    }
}