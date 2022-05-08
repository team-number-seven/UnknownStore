using System.Collections.Generic;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects;

namespace UnknownStore.BusinessLogic.CQRS.Queries.FactoryQueries.GetAllFactories
{
    public record GetAllFactoriesResponse(IEnumerable<GetFactoryDto> FactoryDtos) : ResponseBase;
}