using System;
using AutoMapper;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects.Get
{
    public class GetSizeDto : IMapWith<Size>
    {
        public Guid SizedId { get; set; }
        public string Standard { get; set; }
        public double? MaxValue { get; set; }
        public double? MinValue { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Size, GetSizeDto>()
                .ForMember(dto => dto.SizedId, opt => opt.MapFrom(s => s.Id))
                .ForMember(dto => dto.Standard, opt => opt.MapFrom(s => s.Standard))
                .ForMember(dto => dto.MaxValue, opt => opt.MapFrom(s => s.MaxValue))
                .ForMember(dto => dto.MinValue, opt => opt.MapFrom(s => s.MinValue));
        }
    }
}