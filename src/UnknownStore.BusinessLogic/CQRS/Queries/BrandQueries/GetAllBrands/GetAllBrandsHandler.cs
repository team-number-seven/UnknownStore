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

namespace UnknownStore.BusinessLogic.CQRS.Queries.BrandQueries.GetAllBrands
{
    public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetAllBrandsHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllBrandsHandler(
            IStoreDbContext context,
            IMapper mapper,
            ILogger<GetAllBrandsHandler> logger
        )
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _context.Brands.OrderBy(b=>b.Title).ToListAsync(cancellationToken);
            var brandsDtos = MapBrandsToGetBrandDtos(brands);
            _logger.LogInformation(LoggerMessages.QueryExecutedSuccessfully(nameof(GetAllBrandsHandler)));
            return new GetAllBrandsResponse(brandsDtos);
        }

        private IEnumerable<GetBrandDto> MapBrandsToGetBrandDtos(IEnumerable<Brand> brands)
        {
            var brandDtos = brands.Select(brand => _mapper.Map<GetBrandDto>(brand)).ToList();
            return brandDtos;
        }
    }
}