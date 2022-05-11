using System;
using MediatR;
using UnknownStore.Common.CQRS;

namespace UnknownStore.BusinessLogic.CQRS.Queries.ModelQueries.GetModelById
{
    public record GetModelByIdQuery(Guid ModelId) : IRequest<ResponseBase>;
}