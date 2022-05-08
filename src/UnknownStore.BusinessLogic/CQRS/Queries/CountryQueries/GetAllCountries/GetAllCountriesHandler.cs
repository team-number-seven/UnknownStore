using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using UnknownStore.Common.CQRS;
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
            ILogger<GetAllCountriesHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<ResponseBase> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}