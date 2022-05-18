using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.DAL.Entities.Enums;
using UnknownStore.DAL.Entities.Store;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.OrderCommands.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<CreateOrderHandler> _logger;

        public CreateOrderHandler
        (
            IStoreDbContext context,
            ILogger<CreateOrderHandler> logger
        )
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var dto = request.OrderDto;
            var address = await FindOrCreateAddressAsync(dto.CountryId, dto.DeliveryCity, dto.AddressLine, cancellationToken);

            var buyModels = dto.BuyModels.Select(buyModel => new BuyModel
                { ModelId = buyModel.ModelId, Size = buyModel.Size, Amount = buyModel.Amount }).ToList();
            var order = new Order
            {
                TotalPrice = dto.TotalPrice,
                Discount = dto.Discount,
                PhoneNumber = dto.PhoneNumber,
                FirstName = dto.FirstName,
                DeliveryCost = dto.DeliveryCost,
                CreteDate = DateTime.Now.ToString("s"),
                PaymentMode = Enum.Parse<PaymentMode>(dto.PaymentMode),
                DeliveryMode = Enum.Parse<DeliveryMode>(dto.DeliveryMode),
                OrderStatus = OrderStatus.PendingConfirmation,
                UserId = dto.UserId,
                DeliveryCityId = dto.DeliveryCity,
                DeliveryAddress = address,
                BuyModels = buyModels,
                OrderDescription = dto.OrderDescription,
            };
            UpdateCountSizeModels(order.BuyModels);
            await _context.Orders.AddAsync(order, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation(LoggerMessages.CommandExecutedSuccessfully(nameof(CreateOrderHandler)));
            return new CreateOrderResponse { StatusCode = HttpStatusCode.Created };
        }

        private async Task<Address> FindOrCreateAddressAsync(Guid countryId, Guid deliveryCityId, string addressLine,
            CancellationToken cancellationToken = new())
        {
            var deliveryCity = await _context.DeliveryCities.FindAsync(deliveryCityId);
            var address = await _context.Addresses.FirstOrDefaultAsync(a =>
                    a.CountryId == countryId && a.CityId == deliveryCity.CityId && a.AddressLine == addressLine,
                cancellationToken: cancellationToken);
            return address ?? new Address { AddressLine = addressLine, CityId = deliveryCity.CityId, CountryId = countryId };
        }

        private void UpdateCountSizeModels(IEnumerable<BuyModel> buyModels)
        {
            foreach (var buyModel in buyModels)
            {
                var model = _context.Models.Find(buyModel.ModelId);
                foreach (var amountOfSize in model.AmountOfSizes)
                {
                    if (amountOfSize.Value != buyModel.Size) continue;
                    amountOfSize.Amount -= buyModel.Amount;
                    break;
                }

                _context.Models.Update(model);
            }

            _context.SaveChangesAsync();
        }
    }
}