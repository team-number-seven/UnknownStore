using System;
using AutoMapper;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects.Get
{
    public class GetDeliveryCityDto : IMapWith<DeliveryCity>
    {
        public Guid Id { get; set; }
        public GetCityDto City { get; set; }
        public string MaxTimeDelivered { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeliveryCity, GetDeliveryCityDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(dc => dc.Id))
                .ForMember(dto => dto.MaxTimeDelivered, opt => opt.MapFrom(dc => dc.MaxTimeDelivered))
                .ForMember(dto => dto.City, opt => opt.Ignore());
        }
    }
}