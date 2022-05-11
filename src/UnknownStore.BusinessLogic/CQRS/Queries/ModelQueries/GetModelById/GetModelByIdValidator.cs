using System.Threading;
using System.Threading.Tasks;
using UnknownStore.Common.CQRS.Validation;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Queries.ModelQueries.GetModelById
{
    public class GetModelByIdValidator : IValidationHandler<GetModelByIdQuery>
    {
        private readonly IStoreDbContext _context;

        public GetModelByIdValidator(
            IStoreDbContext context
        )
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(GetModelByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Models.FindAsync(request.ModelId) is null
                ? ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(request.ModelId)))
                : ValidationResult.Success;
        }
    }
}