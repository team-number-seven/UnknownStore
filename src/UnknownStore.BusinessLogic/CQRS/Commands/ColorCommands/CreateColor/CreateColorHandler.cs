using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.DAL.Entities.Store;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.ColorCommands.CreateColor
{
    public class CreateColorHandler : IRequestHandler<CreateColorCommand, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<CreateColorHandler> _logger;

        public CreateColorHandler
        (
            IStoreDbContext context,
            ILogger<CreateColorHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
            var dto = request.ColorDto;
            var color = new Color { HexCode = dto.HexCode, Title = dto.Title };

            await _context.Colors.AddAsync(color, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(LoggerMessages.CommandExecutedSuccessfully(nameof(CreateColorHandler)));
            return new CreateColorResponse { StatusCode = HttpStatusCode.Created };
        }
    }
}