using System;
using System.Threading;
using System.Threading.Tasks;
using UnknownStore.Common.CQRS.Validation;
using UnknownStore.DAL.Entities.Enums;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.OrderCommands.UpdateOrderStatus
{
    public class UpdateOrderStatusValidator : IValidationHandler<UpdateOrderStatusCommand>
    {
        private readonly IStoreDbContext _context;

        public UpdateOrderStatusValidator
        (
            IStoreDbContext context
        )
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(UpdateOrderStatusCommand request,
            CancellationToken cancellationToken)
        {
            var dto = request.UpdateOrderStatusDto;
            if (dto is null)
                return ValidationResult.Fail(
                    ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(request.UpdateOrderStatusDto)));

            if (await _context.Orders.FindAsync(dto.OrderId) is null)
                return ValidationResult.Fail(ValidationMessenger.NotFoundEntity(nameof(dto.OrderId)));

            return Enum.TryParse<OrderStatus>(dto.OrderStatus, out var _) is false
                ? ValidationResult.Fail(ValidationMessenger.InvalidValue(nameof(dto.OrderStatus), dto.OrderStatus))
                : ValidationResult.Success;
        }
    }
}