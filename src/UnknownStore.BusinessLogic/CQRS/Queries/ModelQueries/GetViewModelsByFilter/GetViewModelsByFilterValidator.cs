using System.Threading;
using System.Threading.Tasks;
using UnknownStore.Common.CQRS.Validation;

namespace UnknownStore.BusinessLogic.CQRS.Queries.ModelQueries.GetViewModelsByFilter
{
    public class GetViewModelsByFilterValidator : IValidationHandler<GetViewModelsByFilterQuery>
    {
        public Task<ValidationResult> Validate(GetViewModelsByFilterQuery request,
            CancellationToken cancellationToken)
        {
            var filter = request.Filter;

            return Task.FromResult(ValidationResult.Success);
        }
    }
}