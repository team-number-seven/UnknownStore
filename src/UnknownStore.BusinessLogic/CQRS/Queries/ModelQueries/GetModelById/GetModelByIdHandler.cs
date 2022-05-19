using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Get;
using UnknownStore.DAL.Entities.Store;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Queries.ModelQueries.GetModelById
{
    public class GetModelByIdHandler : IRequestHandler<GetModelByIdQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetModelByIdHandler> _logger;
        private readonly IMapper _mapper;

        public GetModelByIdHandler(
            IStoreDbContext context,
            IMapper mapper,
            ILogger<GetModelByIdHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetModelByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _context.Models.FindAsync(request.ModelId);
            var modelDto = await MapModelToGetModelDtoAsync(model, cancellationToken);
            _logger.LogInformation(LoggerMessages.QueryExecutedSuccessfully(nameof(GetModelByIdHandler)));

            return new GetModelByIdResponse(modelDto);
        }

        private async Task<GetModelDto> MapModelToGetModelDtoAsync(Model model, CancellationToken cancellationToken)
        {
            var modelDto = _mapper.Map<GetModelDto>(model);
            modelDto.SubCategory = _mapper.Map<GetSubCategoryDto>(model.SubCategory);
            modelDto.Brand = _mapper.Map<GetBrandDto>(model.Brand);
            modelDto.Color = _mapper.Map<GetColorDto>(model.Color);
            modelDto.Factory = _mapper.Map<GetFactoryDto>(model.Factory);
            modelDto.Season = _mapper.Map<GetSeasonDto>(model.Season);
            modelDto.AmountOfSize = model.AmountOfSizes
                .Select(amountOfSize => _mapper.Map<GetAmountOfSizeDto>(amountOfSize)).ToList();
            new FileExtensionContentTypeProvider().TryGetContentType(model.MainImage.Format, out var contentType);
            modelDto.MainImage = new FileContentResult(await File.ReadAllBytesAsync
                (model.MainImage.Path, cancellationToken), contentType);
            var imageDtos = new List<FileContentResult>();
            foreach (var image in model.Images)
            {
                new FileExtensionContentTypeProvider().TryGetContentType(image.Format, out contentType);
                imageDtos.Add(new FileContentResult(await File.ReadAllBytesAsync
                    (model.MainImage.Path, cancellationToken), contentType));
            }

            modelDto.Images = imageDtos;

            return modelDto;
        }
    }
}