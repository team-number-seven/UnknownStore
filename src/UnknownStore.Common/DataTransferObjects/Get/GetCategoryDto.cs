using System;
using System.Collections.Generic;
using AutoMapper;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects.Get
{
    public class GetCategoryDto : IMapWith<Category>
    {
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public GetAgeTypeDto AgeType { get; set; }
        public GetGenderDto Gender { get; set; }
        public IEnumerable<GetSubCategoryDto> SubCategories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, GetCategoryDto>()
                .ForMember(dto => dto.CategoryId, opt => opt.MapFrom(c => c.Id))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(c => c.Title))
                .ForMember(dto => dto.AgeType, opt => opt.Ignore())
                .ForMember(dto=>dto.Gender,opt=>opt.Ignore())
                .ForMember(dto => dto.SubCategories, opt => opt.Ignore());
        }
    }
}