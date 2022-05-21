using System;
using System.Collections.Generic;
using AutoMapper;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects.Get
{
    public class GetCountryDto : IMapWith<Country>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<GetCityDto> Cities { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Country, GetCountryDto>()
                .ForMember(dto => dto.Title, opt => opt.MapFrom(c => c.Title))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(dto => dto.Cities, opt => opt.Ignore());
        }
    }
}