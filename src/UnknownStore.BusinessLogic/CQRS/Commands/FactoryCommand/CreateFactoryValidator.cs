using System.Threading;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using UnknownStore.Common.CQRS.Validation;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.FactoryCommand
{
    public class CreateFactoryValidator : IValidationHandler<CreateFactoryCommand>
    {
        private readonly IStoreDbContext _context;

        public CreateFactoryValidator(IStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(CreateFactoryCommand request, CancellationToken cancellationToken)
        {
            var dto = request.CreateFactoryDto;
            if (request.CreateFactoryDto is null)
            {
                return ValidationResult.Fail(
                    ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(request.CreateFactoryDto)));
            }

            var country = await _context.Countries.FindAsync(dto.CountryId);
            var city = await _context.Cities.FindAsync(dto.CityId);

            if (country is null)
            {
                return ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.CountryId)));
            }

            if (city is null)
            {
                return ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.CityId)));
            }

            if (city.CountryId != country.Id)
            {
                return ValidationResult.Fail(
                    ValidationMessenger.InvalidValue(nameof(dto.CityId), dto.CityId.ToString()));
            }

            if (dto.Title.IsNullOrEmpty())
            {
                return ValidationResult.Fail(ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(dto.Title)));
            }

            if (dto.AddressLine.IsNullOrEmpty())
            {
                return ValidationResult.Fail(ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(dto.AddressLine)));
            }

            return await _context.Addresses.FirstOrDefaultAsync(a => a.AddressLine == dto.AddressLine,
                cancellationToken) is not null
                ? ValidationResult.Fail(ValidationMessenger.ObjectAlreadyExists(nameof(dto.AddressLine)))
                : ValidationResult.Success;
        }
    }
}