using System;
using System.Threading;
using System.Threading.Tasks;
using UnknownStore.Common.CQRS.Validation;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.DeliveryCityCommands.CreateDeliveryCity
{
    public class CreateDeliveryCityValidator : IValidationHandler<CreateDeliveryCityCommand>
    {
        private readonly IStoreDbContext _context;

        public CreateDeliveryCityValidator(IStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(CreateDeliveryCityCommand request,
            CancellationToken cancellationToken)
        {
            if (request.DeliveryCityDto is null)
                return ValidationResult.Fail(
                    ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(request.DeliveryCityDto)));

            var dto = request.DeliveryCityDto;
            var parseResult = TimeSpan.TryParse(dto.MaxTimeDelivery, out var timeSpan);

            if (parseResult is false)
                return ValidationResult.Fail(
                    ValidationMessenger.InvalidFormat(nameof(dto.MaxTimeDelivery), dto.MaxTimeDelivery));

            return await _context.Cities.FindAsync(dto.CityId) is null
                ? ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.CityId)))
                : ValidationResult.Success;
        }
    }
}