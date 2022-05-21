using System.Threading;
using System.Threading.Tasks;
using UnknownStore.Common.CQRS.Validation;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.UserCommands.CreateFavoriteItem
{
    public class CreateFavoriteModelValidator : IValidationHandler<CreateFavoriteModelCommand>
    {
        private readonly IStoreDbContext _context;

        public CreateFavoriteModelValidator
        (
            IStoreDbContext context
        )
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(CreateFavoriteModelCommand request,
            CancellationToken cancellationToken)
        {
            var dto = request.FavoriteModelDto;
            if (dto is null)
                return ValidationResult.Fail(
                    ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(request.FavoriteModelDto)));

            if (await _context.Users.FindAsync(dto.UserId) is null)
                return ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.UserId)));

            return await _context.Models.FindAsync(dto.ModelId) is null
                ? ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.ModelId)))
                : ValidationResult.Success;
        }
    }
}