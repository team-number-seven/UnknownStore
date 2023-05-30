using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UnknownStore.BusinessLogic.Extensions;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Get;
using UnknownStore.DAL.Entities.Store;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Queries.ModelQueries.GetViewModelsByFilter
{
    public class GetViewModelsByFilterHandler : IRequestHandler<GetViewModelsByFilterQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetViewModelsByFilterHandler> _logger;
        private readonly IMapper _mapper;

        public GetViewModelsByFilterHandler(
            IStoreDbContext context,
            IMapper mapper,
            ILogger<GetViewModelsByFilterHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetViewModelsByFilterQuery request, CancellationToken cancellationToken)
        {
            var modelsFilter =
                await FiltrationModelsAsync(_context.Models.AsQueryable(), request.Filter, cancellationToken);
            var modelsDtos = await MapModelsToGetViewModelsAsync(modelsFilter, cancellationToken);

            _logger.LogInformation(LoggerMessages.QueryExecutedSuccessfully(nameof(GetViewModelsByFilterHandler)));
            return new GetViewModelsByFilterResponse(modelsDtos);
        }

        private async Task<IEnumerable<Model>> FiltrationModelsAsync(IQueryable<Model> models,
            GetViewModelFilterDto filter, CancellationToken cancellationToken)
        {
            models = models.FilterByBrands(filter.BrandsId?.ToList());
            models = models.FilterByAgeTypesId(filter.AgeTypesId?.ToList());
            models = models.FilterByCategories(filter.CategoriesId?.ToList());
            models = models.FilterBySubCategories(filter.SubCategoriesId.ToList());
            models = models.FilterByColors(filter.ColorsId?.ToList());
            models = models.FilterByGenders(filter.GendersId?.ToList());
            models = models.FilterByIsAvailable(filter.IsAvailable);
            models = models.FilterByMaxPrice(filter.MaxPrice);
            models = models.FilterByMinPrice(filter.MinPrice);
            models = models.FilterBySeasons(filter.SeasonsId?.ToList());
            models = models.FilterByTitle(filter.Title);

            return await models.OrderBy(m=>m.Title).ToListAsync(cancellationToken);
        }

        private async Task<IEnumerable<GetViewModelDto>> MapModelsToGetViewModelsAsync(IEnumerable<Model> models,
            CancellationToken cancellationToken)
        {
            var dtos = new List<GetViewModelDto>();
            foreach (var model in models)
            {
                var dto = _mapper.Map<GetViewModelDto>(model);
                dto.Brand = _mapper.Map<GetBrandDto>(model.Brand);
                dto.SubCategory = _mapper.Map<GetSubCategoryDto>(model.SubCategory);
                new FileExtensionContentTypeProvider().TryGetContentType(model.MainImage.Format, out var contentType);
                dto.MainImage =
                    new FileContentResult(await File.ReadAllBytesAsync(model.MainImage.Path, cancellationToken),
                        contentType);
                dtos.Add(dto);
            }

            return dtos;
        }
    }
}