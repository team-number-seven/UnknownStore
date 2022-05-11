using System;
using AutoMapper;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects.Get
{
    public class GetGenderDto : IMapWith<Gender>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Gender, GetGenderDto>()
                .ForMember(dto => dto.Title, opt => opt.MapFrom(g => g.Title))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(g => g.Id));
        }
    }
}