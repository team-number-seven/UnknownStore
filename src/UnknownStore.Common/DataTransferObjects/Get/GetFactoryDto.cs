﻿using System;
using AutoMapper;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects.Get
{
    public class GetFactoryDto : IMapWith<Factory>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public GetAddressDto Address { get; set; }
        public GetCountryDto Country { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Factory, GetFactoryDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(dto => dto.Address, opt => opt.MapFrom(c => c.Address))
                .ForMember(dto => dto.Country, opt => opt.Ignore())
                .ForMember(dto => dto.Title, opt => opt.MapFrom(c => c.Title));
        }
    }
}