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

namespace UnknownStore.BusinessLogic.CQRS.Queries.DeliveryCityQueries.GetAllDeliveryCities
{
    public class GetAllDeliveryCityHandler : IRequestHandler<GetAllDeliveryCityQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetAllDeliveryCityHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllDeliveryCityHandler
        (
            IStoreDbContext context,
            IMapper mapper,
            ILogger<GetAllDeliveryCityHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetAllDeliveryCityQuery request, CancellationToken cancellationToken)
        {
            var deliveryCityDtos =
                MapDeliveryCitiesToDtos(await _context.DeliveryCities.OrderBy(c=>c.City.Title).ToListAsync(cancellationToken));

            _logger.LogInformation(LoggerMessages.QueryExecutedSuccessfully(nameof(GetAllDeliveryCityHandler)));
            return new GetAllDeliveryCityResponse(deliveryCityDtos);
        }

        private IEnumerable<GetDeliveryCityDto> MapDeliveryCitiesToDtos(IEnumerable<DeliveryCity> deliveryCities)
        {
            var deliveryCityDtos = new List<GetDeliveryCityDto>();
            foreach (var deliveryCity in deliveryCities)
            {
                var dto = _mapper.Map<GetDeliveryCityDto>(deliveryCity);
                dto.City = _mapper.Map<GetCityDto>(deliveryCity.City);
                deliveryCityDtos.Add(dto);
            }

            return deliveryCityDtos;
        }
    }
}