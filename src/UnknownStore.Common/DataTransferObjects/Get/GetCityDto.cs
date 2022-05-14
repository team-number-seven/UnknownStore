using System;
using AutoMapper;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects.Get
{
    public class GetCityDto : IMapWith<City>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<City, GetCityDto>()
                .ForMember(dto => dto.Title, opt => opt.MapFrom(c => c.Title))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(c => c.Id));
        }
    }
}