using System;
using AutoMapper;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects
{
    public class GetAgeTypeDto : IMapWith<AgeType>
    {
        public Guid AgeTypeId { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AgeType, GetAgeTypeDto>()
                .ForMember(dto => dto.Title, opt => opt.MapFrom(at => at.Title))
                .ForMember(dto => dto.AgeTypeId, opt => opt.MapFrom(at => at.Id));
        }
    }
}