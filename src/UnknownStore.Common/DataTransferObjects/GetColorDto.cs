using System;
using AutoMapper;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects
{
    public class GetColorDto : IMapWith<Color>
    {
        public Guid ColorId { get; set; }
        public string Title { get; set; }
        public string HexCode { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Color, GetColorDto>()
                .ForMember(dto => dto.Title, opt => opt.MapFrom(c => c.Title))
                .ForMember(dto => dto.ColorId, opt => opt.MapFrom(c => c.Id))
                .ForMember(dto => dto.HexCode, opt => opt.MapFrom(c => c.HexCode));
        }
    }
}