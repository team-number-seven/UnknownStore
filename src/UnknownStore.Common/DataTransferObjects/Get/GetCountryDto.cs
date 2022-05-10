using System;
using AutoMapper;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects.Get
{
    public class GetCountryDto : IMapWith<Country>
    {
        public Guid CountryId { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Country, GetCountryDto>()
                .ForMember(dto => dto.Title, opt => opt.MapFrom(c => c.Title))
                .ForMember(dto => dto.CountryId, opt => opt.MapFrom(c => c.Id));
        }
    }
}