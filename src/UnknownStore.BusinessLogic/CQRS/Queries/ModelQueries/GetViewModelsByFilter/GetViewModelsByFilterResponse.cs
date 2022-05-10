using System.Collections.Generic;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Get;

namespace UnknownStore.BusinessLogic.CQRS.Queries.ModelQueries.GetViewModelsByFilter
{
    public record GetViewModelsByFilterResponse(IEnumerable<GetViewModelDto> ModelDtos) : ResponseBase;
}