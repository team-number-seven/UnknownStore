using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.DAL.Entities.Store;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.DeliveryPointCommand.CreateDeliveryPoint
{
    public class CreateDeliveryPointHandler : IRequestHandler<CreateDeliveryPointCommand, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<CreateDeliveryPointHandler> _logger;


        public CreateDeliveryPointHandler
        (
            IStoreDbContext context,
            ILogger<CreateDeliveryPointHandler> logger
        )
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(CreateDeliveryPointCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            var deliveryPoint = new DeliveryPoint
            {
                Address = new Address
                {
                    AddressLine = dto.AddressLine,
                    CityId = dto.CityId
                },
                PhoneNumber = dto.PhoneNumber,
                WorkDays = dto.WorkDays.Select(dayDto => new WorkDay
                {
                    DayOfWeek = Enum.Parse<DayOfWeek>(dayDto.DayOfWeek, true),
                    StartOfWork = TimeSpan.Parse(dayDto.StartOfWork),
                    EndOfWork = TimeSpan.Parse(dayDto.EndOfWork)
                }).ToList()
            };
            _logger.LogInformation(LoggerMessages.CommandExecutedSuccessfully(nameof(CreateDeliveryPointHandler)));
            await _context.DeliveryPoints.AddAsync(deliveryPoint, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseBase();
        }
    }
}