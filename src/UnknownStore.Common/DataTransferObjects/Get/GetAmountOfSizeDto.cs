using System;
using AutoMapper;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects.Get
{
    public class GetAmountOfSizeDto : IMapWith<AmountOfSize>
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public double? Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AmountOfSize, GetAmountOfSizeDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(a => a.Id))
                .ForMember(dto => dto.Value, opt => opt.MapFrom(a => a.Value))
                .ForMember(dto => dto.Amount, opt => opt.MapFrom(a => a.Amount));
        }
    }
}