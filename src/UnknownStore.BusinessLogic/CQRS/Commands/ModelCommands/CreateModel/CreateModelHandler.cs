using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using UnknownStore.BusinessLogic.Extensions;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.DAL.Entities.Store;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.BusinessLogic.CQRS.Commands.ModelCommands.CreateModel
{
    public class CreateModelHandler : IRequestHandler<CreateModelCommand, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<CreateModelHandler> _logger;
        private readonly string _pathToImages;

        public CreateModelHandler(
            IStoreDbContext context,
            ILogger<CreateModelHandler> logger,
            IConfiguration configuration
        )
        {
            _pathToImages = configuration["CurrentDirectory"] + configuration["ImagePath"];
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            var dto = request.CreateModelDto;
            var model = new Model
            {
                Id = Guid.NewGuid(),
                Images = await CreateImagesAsync(dto.Images, cancellationToken),
                AmountOfSizes = CreateAmountOfSize(dto.AmountOfSize),
                ModelData = CreateModelDataAsync(dto.ModelData),
                SubCategoryId = dto.SubCategoryId,
                BrandId = dto.BrandId, 
                ColorId = dto.ColorId,
                FactoryId = dto.FactoryId,
                Price = dto.Price,
                SeasonId = dto.SeasonId,
                Title = dto.Title,
                Description = dto.Description,
                MainImage = await CreateMainImageAsync(dto.MainImage, cancellationToken)
            };
            await _context.Models.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation(LoggerMessages.CommandExecutedSuccessfully(nameof(CreateModelHandler)));
            return new CreateModelResponse { StatusCode = HttpStatusCode.Created };
        }

        private IEnumerable<ModelData> CreateModelDataAsync(IDictionary<string, string> dtoModelData)
        {
            var modelData = new List<ModelData>();
            modelData.AddRange(dtoModelData.Select(x => new ModelData { Key = x.Key, Value = x.Value }));
            return modelData;
        }

        private IEnumerable<AmountOfSize> CreateAmountOfSize(IDictionary<double, int> dtoAmountOfSize)
        {
            var amountOfSize = new List<AmountOfSize>();
            amountOfSize.AddRange(dtoAmountOfSize.Select(x => new AmountOfSize { Value = x.Key, Amount = x.Value }));
            return amountOfSize;
        }

        private async Task<IEnumerable<Image>> CreateImagesAsync(IEnumerable<IFormFile> files,
            CancellationToken cancellationToken)
        {
            var images = new List<Image>();
            foreach (var file in files)
            {
                var image = new Image { Id = Guid.NewGuid(), Format = file.FileExtension() };
                var imagePath = _pathToImages + image.Id + image.Format;
                image.Path = imagePath;
                await using var stream = File.Create(imagePath);
                await file.CopyToAsync(stream, cancellationToken);
                images.Add(image);
            }

            return images;
        }

        private async Task<MainImage> CreateMainImageAsync(IFormFile file, CancellationToken cancellationToken)
        {
            var image = new MainImage { Id = Guid.NewGuid(), Format = file.FileExtension() };
            var imagePath = _pathToImages + image.Id + image.Format;
            image.Path = imagePath;

            await using var stream = File.Create(imagePath);
            await file.CopyToAsync(stream, cancellationToken);
            return image;
        }
    }
}