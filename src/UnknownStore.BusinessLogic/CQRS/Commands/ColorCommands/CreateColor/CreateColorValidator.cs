using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnknownStore.Common.CQRS.Validation;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.ColorCommands.CreateColor
{
    public class CreateColorValidator : IValidationHandler<CreateColorCommand>
    {
        private readonly IStoreDbContext _context;

        public CreateColorValidator
        (
            IStoreDbContext context
        )
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(CreateColorCommand request, CancellationToken cancellationToken)
        {
            var dto = request.ColorDto;
            if (dto is null)
            {
                return ValidationResult.Fail(ValidationMessenger.PropertyCannotBeNullOrEmpty(nameof(request.ColorDto)));
            }

            return await _context.Colors.FirstOrDefaultAsync(c => c.HexCode == dto.HexCode || c.Title == dto.Title,
                cancellationToken) is not null
                ? ValidationResult.Fail("Title or HexCode already is exist")
                : ValidationResult.Success;
        }
    }
}