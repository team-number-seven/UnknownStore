using System.Collections.Generic;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Get;

namespace UnknownStore.BusinessLogic.CQRS.Queries.UserQueries.GetFavoriteModels
{
    public record GetFavoriteModelsResponse(IEnumerable<GetViewModelDto> ModelDtos) : ResponseBase;
}