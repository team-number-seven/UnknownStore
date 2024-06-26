﻿using System.Collections.Generic;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Get;

namespace UnknownStore.BusinessLogic.CQRS.Queries.CountryQueries.GetAllCountries
{
    public record GetAllCountriesResponse(IEnumerable<GetCountryDto> CountryDtos) : ResponseBase;
}