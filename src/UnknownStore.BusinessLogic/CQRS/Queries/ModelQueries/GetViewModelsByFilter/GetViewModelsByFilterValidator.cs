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
            if (filter.Count < 1)
                return Task.FromResult(ValidationResult.Fail(ValidationMessenger.InvalidValue(nameof(filter.Count),
                    filter.Count.ToString())));

            return Task.FromResult(ValidationResult.Success);
        }
    }
}