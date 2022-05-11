using System;
using AutoMapper;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects.Get
{
    public class GetSubCategoryDto : IMapWith<SubCategory>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public GetSizeDto Size { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SubCategory, GetSubCategoryDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(sc => sc.Id))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(sc => sc.Title))
                .ForMember(dto => dto.Size, opt => opt.Ignore());
        }
    }
}