﻿using System;
using AutoMapper;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects
{
    public class GetSubCategoryDto : IMapWith<SubCategory>
    {
        public Guid SubCategoryId { get; set; }
        public string Title { get; set; }
        public GetGenderDto Gender { get; set; }
        public GetSizeDto Size { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SubCategory, GetSubCategoryDto>()
                .ForMember(dto => dto.SubCategoryId, opt => opt.MapFrom(sc => sc.Id))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(sc => sc.Title))
                .ForMember(dto => dto.Gender, opt => opt.Ignore())
                .ForMember(dto => dto.Size, opt => opt.Ignore());
        }
    }
}