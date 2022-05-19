using System.Collections.Generic;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Get;

namespace UnknownStore.BusinessLogic.CQRS.Queries.DeliveryCityQueries.GetAllDeliveryCities
{
    public record GetAllDeliveryCityResponse(IEnumerable<GetDeliveryCityDto> DeliveryCityDtos) : ResponseBase;
}