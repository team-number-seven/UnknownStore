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
                return ValidationResult.Fail(
                    ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(request.CreateFactoryDto)));

            if (dto.Title.IsNullOrEmpty())
                return ValidationResult.Fail(ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(dto.Title)));

            if (dto.Address.IsNullOrEmpty())
                return ValidationResult.Fail(ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(dto.Address)));

            if (await _context.Factories.FirstOrDefaultAsync(f => f.Address == dto.Address, cancellationToken) is not
                null)
                return ValidationResult.Fail(ValidationMessenger.ObjectAlreadyExists(nameof(dto.Address)));

            return await _context.Countries.FindAsync(dto.CountryId) is null
                ? ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.CountryId)))
                : ValidationResult.Success;
        }
    }
}