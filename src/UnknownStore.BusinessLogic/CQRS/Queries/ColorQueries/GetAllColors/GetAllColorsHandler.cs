using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UnknownStore.Common.CQRS;
using System;

namespace UnknownStore.BusinessLogic.CQRS.Queries.ColorQueries.GetAllColors
{
    public class GetAllColorsHandler:IRequestHandler<GetAllColorsQuery,ResponseBase>
    {
        public Task<ResponseBase> Handle(GetAllColorsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
