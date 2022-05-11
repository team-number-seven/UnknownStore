using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Get;

namespace UnknownStore.BusinessLogic.CQRS.Queries.ModelQueries.GetModelById
{
    public record GetModelByIdResponse(GetModelDto ModelDto) : ResponseBase;
}