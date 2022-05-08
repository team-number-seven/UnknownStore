﻿using System.Collections.Generic;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects;

namespace UnknownStore.BusinessLogic.CQRS.Queries.BrandQueries.GetAllBrands
{
    public record GetAllBrandsResponse(IEnumerable<GetBrandDto> BrandDtos) : ResponseBase;
}