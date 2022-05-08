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

namespace UnknownStore.BusinessLogic.CQRS.Queries.SeasonQueries.GetAllSeasons
{
    public class GetAllSeasonsHandler : IRequestHandler<GetAllSeasonsQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetAllSeasonsHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllSeasonsHandler(
            IStoreDbContext context,
            IMapper mapper,
            ILogger<GetAllSeasonsHandler> logger
        )
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetAllSeasonsQuery request, CancellationToken cancellationToken)
        {
            var seasons = await _context.Seasons.ToListAsync(cancellationToken);
            var seasonDtos = MapSeasonsToGetSeasonDtos(seasons);
            _logger.LogInformation(LoggerMessages.QueryExecutedSuccessfully(nameof(GetAllSeasonsHandler)));
            return new GetAllSeasonsResponse(seasonDtos);
        }

        private IEnumerable<GetSeasonDto> MapSeasonsToGetSeasonDtos(IEnumerable<Season> seasons)
        {
            var seasonDtos = seasons.Select(season => _mapper.Map<GetSeasonDto>(season)).ToList();
            return seasonDtos;
        }
    }
}