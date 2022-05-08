using System;
using AutoMapper;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects
{
    public class GetSeasonDto : IMapWith<Season>
    {
        public Guid SeasonId { get; set; }
        public string Title { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Season, GetSeasonDto>()
                .ForMember(dto => dto.SeasonId, opt => opt.MapFrom(s => s.Id))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(s => s.Title));
        }
    }
}