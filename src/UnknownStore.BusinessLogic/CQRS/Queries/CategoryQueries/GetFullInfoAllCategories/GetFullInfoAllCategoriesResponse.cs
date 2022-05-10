using System.Collections.Generic;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects;
using UnknownStore.Common.DataTransferObjects.Get;

namespace UnknownStore.BusinessLogic.CQRS.Queries.CategoryQueries.GetFullInfoAllCategories
{
    public record GetFullInfoAllCategoriesResponse(IEnumerable<GetCategoryDto> CategoryDtos) : ResponseBase;
}