using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.DAL.Entities.Enums;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.OrderCommands.UpdateOrderStatus
{
    public class UpdateOrderStatusHandler : IRequestHandler<UpdateOrderStatusCommand, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<UpdateOrderStatusHandler> _logger;

        public UpdateOrderStatusHandler
        (
            IStoreDbContext context,
            ILogger<UpdateOrderStatusHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var dto = request.UpdateOrderStatusDto;

            var order = await _context.Orders.FindAsync(dto.OrderId);
            order.OrderStatus = Enum.Parse<OrderStatus>(dto.OrderStatus);
            _context.Orders.Update(order);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(LoggerMessages.CommandExecutedSuccessfully(nameof(UpdateOrderStatusHandler)));
            return new UpdateOrderStatusResponse();
        }
    }
}