using System;
using AutoMapper;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Mappings
{
    public class LandmarkMapping : Profile
    {
        [Obsolete]
        protected override void Configure()
        {
            CreateMap<Landmark, LandmarkModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LM_NAME))
                .ForMember(dest => dest.LPNumber, opt => opt.MapFrom(src => src.LP_NUMBER))
                .ForMember(dest => dest.ObjectType, opt => opt.MapFrom(src => src.LM_TYPE))
                .ForMember(dest => dest.Lot, opt => opt.MapFrom(src => src.LOT))
                .ForMember(dest => dest.Block, opt => opt.MapFrom(src => src.BLOCK))
            ;

            CreateMap<LandmarkModel, Landmark>()
                .ForMember(dest => dest.LM_NAME, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LP_NUMBER, opt => opt.MapFrom(src => src.LPNumber))
                .ForMember(dest => dest.LM_TYPE, opt => opt.MapFrom(src => src.ObjectType))
                .ForMember(dest => dest.LOT, opt => opt.MapFrom(src => src.Lot))
                .ForMember(dest => dest.BLOCK, opt => opt.MapFrom(src => src.Block))
                ;
        }
    }
}

