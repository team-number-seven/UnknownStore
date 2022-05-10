using System.Collections.Generic;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Get;

namespace UnknownStore.BusinessLogic.CQRS.Queries.SeasonQueries.GetAllSeasons
{
    public record GetAllSeasonsResponse(IEnumerable<GetSeasonDto> SeasonDtos) : ResponseBase;
}