using System.Threading;
using System.Threading.Tasks;
using UnknownStore.Common.CQRS.Validation;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryValidator : IValidationHandler<CreateCategoryCommand>
    {
        private readonly IStoreDbContext _context;

        public CreateCategoryValidator
        (
            IStoreDbContext context
        )
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var dto = request.CategoryDto;
            if (dto is null)
            {
                return ValidationResult.Fail(
                    ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(request.CategoryDto)));
            }

            if (await _context.AgeTypes.FindAsync(dto.AgeTypeId) is null)
            {
                return ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.AgeTypeId)));
            }

            return await _context.Genders.FindAsync(dto.GenderId) is null
                ? ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.GenderId)))
                : ValidationResult.Success;
        }
    }
}