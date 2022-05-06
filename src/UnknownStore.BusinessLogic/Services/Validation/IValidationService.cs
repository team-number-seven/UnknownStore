using UnknownStore.Common.CQRS.Validation;

namespace UnknownStore.BusinessLogic.Services.Validation
{
    public interface IValidationService
    {
        ValidationResult ReferencedObjectsCheckForNull(params ReferencedObjectCheckForNull[] objects);
    }
}