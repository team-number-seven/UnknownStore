using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnknownStore.Common.CQRS.Validation;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.UserCommands.DeleteFavoriteItem
{
    public class DeleteFavoriteItemValidator : IValidationHandler<DeleteFavoriteItemCommand>
    {
        private readonly IStoreDbContext _context;

        public DeleteFavoriteItemValidator
        (
            IStoreDbContext context
        )
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(DeleteFavoriteItemCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user is null)
                return ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(request.UserId)));
            return user.FavoriteModels.FirstOrDefault(c => c.Id == request.FavoriteItemId) is null
                ? ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(request.FavoriteItemId)))
                : ValidationResult.Success;
        }
    }
}