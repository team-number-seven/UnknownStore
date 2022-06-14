using System.Collections.Generic;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Get;

namespace UnknownStore.BusinessLogic.CQRS.Queries.GenderQueries.GetAllGenders
{
    public record GetAllGendersResponse(IEnumerable<GetGenderDto> GenderDtos) : ResponseBase;
}