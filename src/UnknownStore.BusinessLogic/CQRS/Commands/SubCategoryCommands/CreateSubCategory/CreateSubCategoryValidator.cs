using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnknownStore.Common.CQRS.Validation;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.SubCategoryCommands.CreateSubCategory
{
    public class CreateSubCategoryValidator : IValidationHandler<CreateSubCategoryCommand>
    {
        private readonly IStoreDbContext _context;

        public CreateSubCategoryValidator
        (
            IStoreDbContext context
        )
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(CreateSubCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var dto = request.SubCategoryDto;
            if (dto is null)
                return ValidationResult.Fail(
                    ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(request.SubCategoryDto)));

            if (await _context.Categories.FindAsync(dto.CategoryId) is null)
                return ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.CategoryId)));

            return await _context.SubCategories.FirstOrDefaultAsync(sb => sb.Title == dto.Title, cancellationToken)
                is not null
                ? ValidationResult.Fail(ValidationMessenger.ObjectAlreadyExists(nameof(dto.Title)))
                : ValidationResult.Success;
        }
    }
}