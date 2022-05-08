using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects;
using UnknownStore.DAL.Entities.Store;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Queries.AgeTypeQueries.GetAllAgeTypes
{
    public class GetAllAgeTypesHandler : IRequestHandler<GetAllAgeTypesQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetAllAgeTypesHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllAgeTypesHandler(
            IStoreDbContext context,
            IMapper mapper,
            ILogger<GetAllAgeTypesHandler> logger
            )
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetAllAgeTypesQuery request, CancellationToken cancellationToken)
        {
            var ageTypes = await _context.AgeTypes.ToListAsync(cancellationToken);
            var ageTypeDtos = MapAgeTypeToGetAgeTypeDtos(ageTypes);
            _logger.LogInformation(LoggerMessages.QueryExecutedSuccessfully(nameof(GetAllAgeTypesHandler)));
            return new GetAllAgeTypesResponse(ageTypeDtos);
        }

        private IEnumerable<GetAgeTypeDto> MapAgeTypeToGetAgeTypeDtos(IEnumerable<AgeType> ageTypes)
        {
            var colorDtos = ageTypes.Select(ageType => _mapper.Map<GetAgeTypeDto>(ageType)).ToList();
            return colorDtos;
        }
    }
}