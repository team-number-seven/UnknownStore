using System.Threading;
using System.Threading.Tasks;
using Castle.Core.Internal;
using UnknownStore.Common.CQRS.Validation;

namespace UnknownStore.BusinessLogic.CQRS.Commands.Model.CreateModel
{
    public class CreateModelValidator:IValidationHandler<CreateModelCommand>
    {
        public async Task<ValidationResult> Validate(CreateModelCommand request, CancellationToken cancellationToken)
        {
            if (request.CreateModelDto is null)
            {
                return ValidationResult.Fail(ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(request.CreateModelDto)));
            }
            var dto = request.CreateModelDto;
            if (dto.AmountOfSize is null || dto.AmountOfSize.IsNullOrEmpty())
            {

            }
        }
    }
}
