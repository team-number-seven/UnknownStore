using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects.Get
{
    public class GetViewModelDto : IMapWith<Model>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public GetBrandDto Brand { get; set; }
        public GetSubCategoryDto SubCategory { get; set; }

        public FileContentResult MainImage { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Model, GetViewModelDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(m => m.Title))
                .ForMember(dto => dto.Price, opt => opt.MapFrom(m => m.Price))
                .ForMember(dto => dto.Brand, opt => opt.Ignore())
                .ForMember(dto => dto.SubCategory, opt => opt.Ignore())
                .ForMember(dto => dto.MainImage, opt => opt.Ignore());
        }
    }
}