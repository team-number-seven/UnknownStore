using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Castle.Core.Internal;
using PhoneNumbers;
using UnknownStore.Common.CQRS.Validation;
using UnknownStore.Common.DataTransferObjects.Create;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.DeliveryPointCommand.CreateDeliveryPoint
{
    public class CreateDeliveryPointValidator : IValidationHandler<CreateDeliveryPointCommand>
    {
        private readonly IStoreDbContext _context;

        public CreateDeliveryPointValidator
        (
            IStoreDbContext context
        )
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(CreateDeliveryPointCommand request,
            CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            if (await _context.Cities.FindAsync(dto.CityId) is null)
                return ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.CityId)));

            if (dto.AddressLine.IsNullOrEmpty())
                return ValidationResult.Fail(ValidationMessenger.PropertyCannotBeNullOrEmpty(dto.AddressLine));

            if (dto.PhoneNumber.IsNullOrEmpty() || IsValidPhoneNumber(dto.PhoneNumber, string.Empty))
                return ValidationResult.Fail(ValidationMessenger.InvalidFormat(dto.PhoneNumber, dto.PhoneNumber));
            return IsValidWorkDays(dto.WorkDays) is false
                ? ValidationResult.Fail(
                    ValidationMessenger.InvalidFormat(nameof(dto.WorkDays), dto.WorkDays.ToString()))
                : ValidationResult.Success;
        }

        public bool IsValidPhoneNumber(string phoneNumber, string region)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            return phoneNumberUtil.IsValidNumber(phoneNumberUtil.Parse(phoneNumber, region));
        }

        public bool IsValidWorkDays(IEnumerable<CreateWorkDayDto> workDayDtos)
        {
            foreach (var workDay in workDayDtos)
            {
                var resultParse = Enum.TryParse<DayOfWeek>(workDay.DayOfWeek, false, out _);
                if (resultParse is false)
                    return false;

                resultParse = TimeSpan.TryParse(workDay.StartOfWork, out _);
                if (resultParse is false)
                    return false;

                resultParse = TimeSpan.TryParse(workDay.EndOfWork, out _);
                if (resultParse is false)
                    return false;
            }

            return true;
        }
    }
}