using System.Collections.Generic;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects;

namespace UnknownStore.BusinessLogic.CQRS.Queries.CategoryQueries.GetAllCategories
{
    public record GetAllCategoriesResponse(IEnumerable<GetCategoryDto> CategoryDtos) : ResponseBase;
}