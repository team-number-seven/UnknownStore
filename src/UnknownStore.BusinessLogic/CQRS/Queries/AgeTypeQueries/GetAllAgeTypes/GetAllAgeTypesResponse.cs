using System.Collections.Generic;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects;

namespace UnknownStore.BusinessLogic.CQRS.Queries.AgeTypeQueries.GetAllAgeTypes
{
    public record GetAllAgeTypesResponse(IEnumerable<GetAgeTypeDto> AgeTypeDtos) : ResponseBase;
}