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
            var countries = await _context.Countries.OrderBy(c => c.Title).ToListAsync(cancellationToken);
            countries.ForEach(country => country.Cities = country.Cities.OrderBy(city => city.Title));
            var countryDtos = MapCountriesToCountryDtos(countries);
            _logger.LogInformation(LoggerMessages.QueryExecutedSuccessfully(nameof(GetAllCountriesHandler)));

            return new GetAllCountriesResponse(countryDtos);
        }

        private IEnumerable<GetCountryDto> MapCountriesToCountryDtos(IEnumerable<Country> countries)
        {
            var countryDtos = new List<GetCountryDto>();
            foreach (var country in countries)
            {
                var countryDto = _mapper.Map<GetCountryDto>(country);
                countryDto.Cities = country.Cities.Select(city => _mapper.Map<GetCityDto>(city)).ToList();
                countryDtos.Add(countryDto);
            }

            return countryDtos;
        }
    }
}