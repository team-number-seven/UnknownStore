using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Get;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Queries.GenderQueries.GetAllGenders
{
    public class GetAllGendersHandler : IRequestHandler<GetAllGendersQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetAllGendersHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllGendersHandler
        (
            IStoreDbContext context,
            ILogger<GetAllGendersHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Handle(GetAllGendersQuery request, CancellationToken cancellationToken)
        {
            var genders = await _context.Genders.OrderBy(f => f.Title).ToListAsync(cancellationToken);
            var gendersDtos = genders.Select(gender => _mapper.Map<GetGenderDto>(gender)).ToList();
            _logger.LogInformation(LoggerMessages.QueryExecutedSuccessfully(nameof(GetAllGendersHandler)));
            return new GetAllGendersResponse(gendersDtos);
        }
    }
}