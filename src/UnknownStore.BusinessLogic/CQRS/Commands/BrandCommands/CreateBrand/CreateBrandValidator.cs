using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnknownStore.Common.CQRS.Validation;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.BrandCommands.CreateBrand
{
    public class CreateBrandValidator : IValidationHandler<CreateBrandCommand>
    {
        private readonly IStoreDbContext _context;

        public CreateBrandValidator
        (
            IStoreDbContext context
        )
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var dto = request.BrandDto;
            if (dto is null)
                return ValidationResult.Fail(ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(request.BrandDto)));

            if (await _context.Countries.FindAsync(dto.CountryId) is null)
                return ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.CountryId)));

            return await _context.Brands.FirstOrDefaultAsync(c => c.Title == dto.Title, cancellationToken) is not null
                ? ValidationResult.Fail(ValidationMessenger.ObjectAlreadyExists(nameof(dto.Title)))
                : ValidationResult.Success;
        }
    }
}