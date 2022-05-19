using MediatR;
using UnknownStore.Common.CQRS;

namespace UnknownStore.BusinessLogic.CQRS.Queries.DeliveryCityQueries.GetAllDeliveryCities
{
    public record GetAllDeliveryCityQuery : IRequest<ResponseBase>;
}