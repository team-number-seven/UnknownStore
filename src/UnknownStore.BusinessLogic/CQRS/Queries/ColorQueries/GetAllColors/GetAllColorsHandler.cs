using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UnknownStore.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UnknownStore.Common;
using UnknownStore.Common.DataTransferObjects;
using UnknownStore.DAL.Entities.Store;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Queries.ColorQueries.GetAllColors
{
    public class GetAllColorsHandler : IRequestHandler<GetAllColorsQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetAllColorsHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllColorsHandler(IStoreDbContext context, ILogger<GetAllColorsHandler> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Handle(GetAllColorsQuery request, CancellationToken cancellationToken)
        {
            var colors = await _context.Colors.ToListAsync(cancellationToken);
            var colorDtos = MapColorsToColorDtos(colors);
            _logger.LogInformation(LoggerMessages.QueryExecutedSuccessfully(nameof(GetAllColorsHandler)));
            return new GetAllColorsResponse(colorDtos);
        }

        private IEnumerable<GetColorDto> MapColorsToColorDtos(IEnumerable<Color> colors)
        {
            var colorDtos = colors.Select(color => _mapper.Map<GetColorDto>(color)).ToList();
            return colorDtos;
        }
    }
}