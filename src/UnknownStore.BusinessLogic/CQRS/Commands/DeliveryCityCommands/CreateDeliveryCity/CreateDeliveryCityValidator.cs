using System.Threading;
using System.Threading.Tasks;
using UnknownStore.Common.CQRS.Validation;

namespace UnknownStore.BusinessLogic.CQRS.Commands.DeliveryCityCommands.CreateDeliveryCity
{
    public class CreateDeliveryCityValidator : IValidationHandler<CreateDeliveryCityCommand>
    {
        public async Task<ValidationResult> Validate(CreateDeliveryCityCommand request, CancellationToken cancellationToken)
        {
            return ValidationResult.Success;
        }
    }
}