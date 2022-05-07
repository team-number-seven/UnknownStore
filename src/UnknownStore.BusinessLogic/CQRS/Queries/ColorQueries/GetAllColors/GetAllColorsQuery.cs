using MediatR;
using UnknownStore.Common.CQRS;

namespace UnknownStore.BusinessLogic.CQRS.Queries.ColorQueries.GetAllColors
{
    public record GetAllColorsQuery : IRequest<ResponseBase>;
}
