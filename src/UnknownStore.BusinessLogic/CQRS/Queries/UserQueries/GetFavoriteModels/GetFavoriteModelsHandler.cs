using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.DataTransferObjects.Get;
using UnknownStore.DAL.Entities.Store;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Queries.UserQueries.GetFavoriteModels
{
    public class GetFavoriteModelsHandler : IRequestHandler<GetFavoriteModelsQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetFavoriteModelsHandler> _logger;
        private readonly IMapper _mapper;

        public GetFavoriteModelsHandler
        (
            IStoreDbContext context,
            ILogger<GetFavoriteModelsHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Handle(GetFavoriteModelsQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            var favoriteModels = await MapModelsToGetViewModelsAsync(user.FavoriteModels, cancellationToken);

            _logger.LogInformation(LoggerMessages.QueryExecutedSuccessfully(nameof(GetFavoriteModelsHandler)));
            return new GetFavoriteModelsResponse(favoriteModels);
        }

        private async Task<IEnumerable<GetViewModelDto>> MapModelsToGetViewModelsAsync(IEnumerable<Model> models,
            CancellationToken cancellationToken = new())
        {
            var dtos = new List<GetViewModelDto>();
            foreach (var model in models)
            {
                var dto = _mapper.Map<GetViewModelDto>(model);
                dto.Brand = _mapper.Map<GetBrandDto>(model.Brand);
                dto.SubCategory = _mapper.Map<GetSubCategoryDto>(model.SubCategory);
                new FileExtensionContentTypeProvider().TryGetContentType(model.MainImage.Format, out var contentType);
                dto.MainImage =
                    new FileContentResult(await File.ReadAllBytesAsync(model.MainImage.Path, cancellationToken),
                        contentType);
                dtos.Add(dto);
            }

            return dtos;
        }
    }
}