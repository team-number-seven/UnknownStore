using System.Threading;
using System.Threading.Tasks;
using UnknownStore.Common.CQRS.Validation;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.OrderCommands.CreateOrder
{
    public class CreateOrderValidator : IValidationHandler<CreateOrderCommand>
    {
        private readonly IStoreDbContext _context;

        public CreateOrderValidator(IStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            return ValidationResult.Success;
        }
    }
}