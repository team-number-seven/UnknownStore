﻿using System.Collections.Generic;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Get;

namespace UnknownStore.BusinessLogic.CQRS.Queries.ColorQueries.GetAllColors
{
    public record GetAllColorsResponse(IEnumerable<GetColorDto> ColorDtos) : ResponseBase;
}