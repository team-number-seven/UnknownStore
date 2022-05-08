using System;
using AutoMapper;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects
{
    public class GetBrandDto : IMapWith<Brand>
    {
        public Guid BrandId { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Brand, GetBrandDto>()
                .ForMember(dto => dto.Title, opt => opt.MapFrom(b => b.Title))
                .ForMember(dto => dto.BrandId, opt => opt.MapFrom(b => b.Id));
        }
    }
}