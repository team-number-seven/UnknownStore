using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Castle.Core.Internal;
using UnknownStore.BusinessLogic.Extensions;
using UnknownStore.Common.CQRS.Validation;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.ModelCommands.CreateModel
{
    public class CreateModelValidator : IValidationHandler<CreateModelCommand>
    {
        private readonly IStoreDbContext _context;

        public CreateModelValidator(IStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(CreateModelCommand request, CancellationToken cancellationToken)
        {
            if (request.CreateModelDto is null)
                return ValidationResult.Fail(
                    ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(request.CreateModelDto)));

            var dto = request.CreateModelDto;

            if (dto.Title.IsNullOrEmpty())
                return ValidationResult.Fail(ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(dto.Title)));

            if (dto.Description.IsNullOrEmpty())
                return ValidationResult.Fail(ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(dto.Description)));

            if (dto.ModelData.IsNullOrEmpty())
                return ValidationResult.Fail(ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(dto.ModelData)));

            if (dto.Images.IsNullOrEmpty())
                return ValidationResult.Fail(ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(dto.Images)));

            if (dto.MainImage is null)
                return ValidationResult.Fail(ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(dto.MainImage)));

            if (await _context.Brands.FindAsync(dto.BrandId) is null)
                return ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.BrandId)));

            if (await _context.Colors.FindAsync(dto.ColorId) is null)
                return ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.ColorId)));

            if (await _context.Factories.FindAsync(dto.FactoryId) is null)
                return ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.FactoryId)));

            if (await _context.Seasons.FindAsync(dto.SeasonId) is null)
                return ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.SeasonId)));

            if (dto.Price < 0)
                return ValidationResult.Fail(ValidationMessenger.InvalidValue(nameof(dto.Price),
                    dto.Price.ToString(CultureInfo.InvariantCulture)));

            foreach (var file in dto.Images)
                if (file.IsImage() is false)
                    return ValidationResult.Fail(ValidationMessenger.InvalidFormat("Image", file.FileExtension()));

            if (dto.MainImage.IsImage() is false)
                return ValidationResult.Fail(ValidationMessenger.InvalidFormat("Image", dto.MainImage.FileExtension()));

            return await _context.SubCategories.FindAsync(dto.SubCategoryId) is null
                ? ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.SubCategoryId)))
                : ValidationResult.Success;
        }
    }
}