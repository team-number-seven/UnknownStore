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

namespace UnknownStore.BusinessLogic.CQRS.Queries.CategoryQueries.GetFullInfoAllCategories
{
    public class GetFullInfoAllCategoriesHandler : IRequestHandler<GetAllFullInfoCategoriesQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetFullInfoAllCategoriesHandler> _logger;
        private readonly IMapper _mapper;

        public GetFullInfoAllCategoriesHandler(
            IStoreDbContext context,
            IMapper mapper,
            ILogger<GetFullInfoAllCategoriesHandler> logger
        )
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetAllFullInfoCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            var categories = await _context.Categories.OrderBy(c => c.Title).ToListAsync(cancellationToken);
            categories.ForEach(c => c.SubCategories = c.SubCategories.OrderBy(sc => sc.Title));
            var categoryDtos = MapCategoriesToGetSubCategories(categories);
            _logger.LogInformation(LoggerMessages.QueryExecutedSuccessfully(nameof(GetFullInfoAllCategoriesHandler)));
            return new GetFullInfoAllCategoriesResponse(categoryDtos);
        }

        private IEnumerable<GetCategoryDto> MapCategoriesToGetSubCategories(IEnumerable<Category> categories)
        {
            var categoryDtos = new List<GetCategoryDto>();
            foreach (var category in categories)
            {
                var categoryDto = _mapper.Map<GetCategoryDto>(category);
                categoryDto.AgeType = _mapper.Map<GetAgeTypeDto>(category.AgeType);
                var subCategoryDtos = new List<GetSubCategoryDto>();
                categoryDto.Gender = _mapper.Map<GetGenderDto>(category.Gender);
                foreach (var subCategory in category.SubCategories)
                {
                    var subCategoryDto = _mapper.Map<GetSubCategoryDto>(subCategory);
                    subCategoryDto.Size = _mapper.Map<GetSizeDto>(subCategory.Size);
                    subCategoryDtos.Add(subCategoryDto);
                }

                categoryDto.SubCategories = subCategoryDtos;
                categoryDtos.Add(categoryDto);
            }

            return categoryDtos;
        }
    }
}