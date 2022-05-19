using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Castle.Core.Internal;
using PhoneNumbers;
using UnknownStore.Common.CQRS.Validation;
using UnknownStore.Common.DataTransferObjects.Create;
using UnknownStore.DAL.Entities.Enums;
using UnknownStore.DAL.Entities.Store;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.OrderCommands.CreateOrder
{
    public class CreateOrderValidator : IValidationHandler<CreateOrderCommand>
    {
        private readonly IStoreDbContext _context;

        public CreateOrderValidator(IStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var dto = request.OrderDto;
            if (dto is null)
                return ValidationResult.Fail(ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(request.OrderDto)));

            if (await _context.DeliveryCities.FindAsync(dto.DeliveryCityId) is null)
                return ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.DeliveryCityId)));

            if (dto.UserId is not null && await _context.Users.FindAsync(dto.UserId) is null)
                return ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.UserId)));

            if (dto.AddressLine.IsNullOrEmpty())
                return ValidationResult.Fail(ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(dto.AddressLine)));

            if (dto.DeliveryCost < 0.0m)
                return ValidationResult.Fail(ValidationMessenger.InvalidValue(nameof(dto.DeliveryCost),
                    dto.DeliveryCost.ToString(CultureInfo.InvariantCulture)));

            if (dto.Discount < 0.0m)
                return ValidationResult.Fail(ValidationMessenger.InvalidValue(nameof(dto.Discount),
                    dto.DeliveryCost.ToString(CultureInfo.InvariantCulture)));

            if (dto.FirstName.IsNullOrEmpty())
                return ValidationResult.Fail(ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(dto.FirstName)));

            if (dto.PhoneNumber.IsNullOrEmpty() || IsValidPhoneNumber(dto.PhoneNumber, string.Empty) is false)
                return ValidationResult.Fail(ValidationMessenger.InvalidFormat(dto.PhoneNumber, dto.PhoneNumber));

            if (Enum.TryParse<DeliveryMode>(dto.DeliveryMode, out var deliveryMode) is false)
                return ValidationResult.Fail(
                    ValidationMessenger.InvalidFormat(nameof(dto.DeliveryMode), dto.DeliveryMode));

            //TODO add delivery points
            //if(result == DeliveryMode.DeliveryPoint && await _context.DeliveryPoints.FirstOrDefault())
            if (Enum.TryParse<PaymentMode>(dto.PaymentMode, out var paymentMode) is false)
                return ValidationResult.Fail(
                    ValidationMessenger.InvalidFormat(nameof(dto.PaymentMode), dto.PaymentMode));

            if (dto.OrderDescription.Length > 500)
                return ValidationResult.Fail(ValidationMessenger.InvalidValue(nameof(dto.OrderDescription.Length),
                    dto.OrderDescription.Length.ToString()));

            return await IsValidBuyModelsAsync(dto.BuyModels);
        }

        public static bool IsValidPhoneNumber(string phoneNumber, string region)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            return phoneNumberUtil.IsValidNumber(phoneNumberUtil.Parse(phoneNumber, region));
        }

        private async Task<ValidationResult> IsValidBuyModelsAsync(IEnumerable<CreateBuyModelDto> buyModels)
        {
            foreach (var buyModel in buyModels)
            {
                var model = await _context.Models.FindAsync(buyModel.ModelId);

                if (model is null)
                    return ValidationResult.Fail(
                        ValidationMessenger.InvalidValue(nameof(buyModel.ModelId), buyModel.ModelId.ToString()));

                var amountOfSize = model.AmountOfSizes.FirstOrDefault(m => m.Id == buyModel.AmountOfSizeId);

                if (amountOfSize is null)
                    return ValidationResult.Fail(
                        ValidationMessenger.InvalidValue(nameof(buyModel.AmountOfSizeId),
                            buyModel.AmountOfSizeId.ToString()));

                if (amountOfSize.Amount < buyModel.Amount)
                    return ValidationResult.Fail(ValidationMessenger.InvalidValue(nameof(buyModel.Amount),
                        buyModel.Amount.ToString()));
            }

            return ValidationResult.Success;
        }
    }
}