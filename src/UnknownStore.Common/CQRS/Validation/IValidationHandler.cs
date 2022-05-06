using System.Threading;
using System.Threading.Tasks;

namespace UnknownStore.Common.CQRS.Validation
{
    public interface IValidationHandler
    {
    }

    public interface IValidationHandler<T> : IValidationHandler
    {
        Task<ValidationResult> Validate(T request, CancellationToken cancellationToken);
    }
}