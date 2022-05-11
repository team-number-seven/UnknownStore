using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects.Get
{
    public class GetModelDto : IMapWith<Model>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public GetBrandDto Brand { get; set; }
        public GetSubCategoryDto SubCategory { get; set; }
        public GetColorDto Color { get; set; }
        public GetFactoryDto Factory { get; set; }
        public GetSeasonDto Season { get; set; }
        public FileContentResult MainImage { get; set; }
        public IEnumerable<FileContentResult> Images { get; set; }
        public IDictionary<double, int> AmountOfSize { get; set; }
        public IDictionary<string, string> ModelData { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Model, GetModelDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(m => m.Title))
                .ForMember(dto => dto.Description, opt => opt.MapFrom(m => m.Description))
                .ForMember(dto => dto.Price, opt => opt.MapFrom(m => m.Price))
                .ForMember(dto => dto.Brand, opt => opt.Ignore())
                .ForMember(dto => dto.SubCategory, opt => opt.Ignore())
                .ForMember(dto => dto.Color, opt => opt.Ignore())
                .ForMember(dto => dto.Factory, opt => opt.Ignore())
                .ForMember(dto => dto.Season, opt => opt.Ignore())
                .ForMember(dto => dto.MainImage, opt => opt.Ignore())
                .ForMember(dto => dto.Images, opt => opt.Ignore())
                .ForMember(dto => dto.AmountOfSize,
                    opt => opt.MapFrom(m => m.AmountOfSizes.ToDictionary(am => am.Value, am => am.Amount)))
                .ForMember(dto => dto.ModelData,
                    opt => opt.MapFrom(m => m.ModelData.ToDictionary(md => md.Key, md => md.Value)));
        }
    }
}