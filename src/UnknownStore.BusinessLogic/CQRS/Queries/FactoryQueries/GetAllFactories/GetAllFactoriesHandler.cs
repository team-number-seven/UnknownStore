﻿using System.Collections.Generic;
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

namespace UnknownStore.BusinessLogic.CQRS.Queries.FactoryQueries.GetAllFactories
{
    public class GetAllFactoriesHandler : IRequestHandler<GetAllFactoriesQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetAllFactoriesHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllFactoriesHandler(
            IStoreDbContext context,
            IMapper mapper,
            ILogger<GetAllFactoriesHandler> logger
        )
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetAllFactoriesQuery request, CancellationToken cancellationToken)
        {
            var factories = await _context.Factories.ToListAsync(cancellationToken);
            var factoryDtos = MapFactoriesToFactoryDtos(factories);
            _logger.LogInformation(LoggerMessages.QueryExecutedSuccessfully(nameof(GetAllFactoriesHandler)));
            return new GetAllFactoriesResponse(factoryDtos);
        }

        private IEnumerable<GetFactoryDto> MapFactoriesToFactoryDtos(IEnumerable<Factory> factories)
        {
            var factoryDtos = new List<GetFactoryDto>();
            foreach (var factory in factories)
            {
                var factoryDto = _mapper.Map<GetFactoryDto>(factory);
                factoryDto.Country = _mapper.Map<GetCountryDto>(factory.Country);
                factoryDtos.Add(factoryDto);
            }

            return factoryDtos;
        }
    }
}