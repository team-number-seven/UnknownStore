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
using UnknownStore.Common.DataTransferObjects.Get;
using UnknownStore.DAL.Entities.Store;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Queries.CountryQueries.GetAllCountries
{
    public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetAllCountriesHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllCountriesHandler(
            IStoreDbContext context,
            IMapper mapper,
            ILogger<GetAllCountriesHandler> logger
            )
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await _context.Countries.ToListAsync(cancellationToken);
            var countryDtos = MapCountriesToCountryDtos(countries);
            _logger.LogInformation(LoggerMessages.QueryExecutedSuccessfully(nameof(GetAllCountriesHandler)));
            return new GetAllCountriesResponse(countryDtos);
        }

        private IEnumerable<GetCountryDto> MapCountriesToCountryDtos(IEnumerable<Country> countries)
        {
            var countryDtos = countries.Select(country => _mapper.Map<GetCountryDto>(country)).ToList();
            return countryDtos;
        }
    }
}