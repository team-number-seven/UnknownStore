using System;
using AutoMapper;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects.Get
{
    public class GetAddressDto : IMapWith<Address>
    {
        public Guid Id { get; set; }
        public string AddressLine { get; set; }
        public GetCountryDto Country { get; set; }
        public GetCityDto City { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, GetAddressDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(dto => dto.AddressLine, opt => opt.MapFrom(c => c.AddressLine))
                .ForMember(dto => dto.Country, opt => opt.Ignore())
                .ForMember(dto => dto.AddressLine, opt => opt.Ignore());
        }
    }
}