using System.Collections.Generic;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects;

namespace UnknownStore.BusinessLogic.CQRS.Queries.CategoryQueries.GetFullInfoAllCategories
{
    public record GetFullInfoAllCategoriesResponse(IEnumerable<GetCategoryDto> CategoryDtos) : ResponseBase;
}