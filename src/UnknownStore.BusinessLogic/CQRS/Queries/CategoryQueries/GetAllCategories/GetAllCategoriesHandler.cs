using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects;
using UnknownStore.DAL.Entities.Store;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Queries.CategoryQueries.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetAllCategoriesHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(
            IStoreDbContext context,
            IMapper mapper,
            ILogger<GetAllCategoriesHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories.ToListAsync(cancellationToken);
            var categoryDtos = MapCategoriesToGetSubCategories(categories);
            _logger.LogInformation(LoggerMessages.QueryExecutedSuccessfully(nameof(GetAllCategoriesHandler)));
            return new GetAllCategoriesResponse(categoryDtos);
        }

        private IEnumerable<GetCategoryDto> MapCategoriesToGetSubCategories(IEnumerable<Category> categories)
        {
            var categoryDtos = new List<GetCategoryDto>();
            foreach (var category in categories)
            {
                var categoryDto = _mapper.Map<GetCategoryDto>(category);
                categoryDto.AgeType = _mapper.Map<GetAgeTypeDto>(category.AgeType);
                var subCategoryDtos = new List<GetSubCategoryDto>();
                foreach (var subCategory in category.SubCategories)
                {
                    var subCategoryDto = _mapper.Map<GetSubCategoryDto>(subCategory);
                    subCategoryDto.Size = _mapper.Map<GetSizeDto>(subCategory.Size);
                    subCategoryDto.Gender = _mapper.Map<GetGenderDto>(subCategory.Gender);
                    subCategoryDtos.Add(subCategoryDto);
                }

                categoryDto.SubCategories = subCategoryDtos;
                categoryDtos.Add(categoryDto);
            }

            return categoryDtos;
        }
    }
}