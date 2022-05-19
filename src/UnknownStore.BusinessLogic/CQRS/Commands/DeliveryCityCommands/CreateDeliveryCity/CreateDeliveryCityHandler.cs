using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using UnknownStore.BusinessLogic.CQRS.Commands.FactoryCommand;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.DAL.Interfaces;
using DeliveryCity = UnknownStore.DAL.Entities.Store.DeliveryCity;

namespace UnknownStore.BusinessLogic.CQRS.Commands.DeliveryCityCommands.CreateDeliveryCity
{
    public class CreateDeliveryCityHandler : IRequestHandler<CreateDeliveryCityCommand, ResponseBase>

    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<CreateDeliveryCityHandler> _logger;

        public CreateDeliveryCityHandler
        (
            IStoreDbContext context,
            ILogger<CreateDeliveryCityHandler> logger
        )
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(CreateDeliveryCityCommand request, CancellationToken cancellationToken)
        {
            var dto = request.DeliveryCityDto;
            var deliveryCity = new DeliveryCity
            {
                CityId = dto.CityId,
                MaxTimeDelivered = TimeSpan.Parse(dto.MaxTimeDelivery)
            };
            await _context.DeliveryCities.AddAsync(deliveryCity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation(LoggerMessages.CommandExecutedSuccessfully(nameof(CreateDeliveryCityHandler)));

            return new CreateFactoryResponse { StatusCode = HttpStatusCode.Created };
        }
    }
}