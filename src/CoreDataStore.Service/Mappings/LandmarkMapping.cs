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
                .ForMember(dest => dest.BBL, opt => opt.MapFrom(src => src.BBL))
                .ForMember(dest => dest.BinNumber, opt => opt.MapFrom(src => src.BIN_NUMBER))
                .ForMember(dest => dest.ObjectType, opt => opt.MapFrom(src => src.LM_TYPE))
                .ForMember(dest => dest.Lot, opt => opt.MapFrom(src => src.LOT))
                .ForMember(dest => dest.Block, opt => opt.MapFrom(src => src.BLOCK))
                .ForMember(dest => dest.DesignatedAddress, opt => opt.MapFrom(src => src.DESIG_ADDR))
                .ForMember(dest => dest.PlutoAddress, opt => opt.MapFrom(src => src.PLUTO_ADDR))
                .ForMember(dest => dest.IsCurrent, opt => opt.MapFrom(src => src.MOST_CURRE))
                .ForMember(dest => dest.IsVacantLot, opt => opt.MapFrom(src => src.VACANT_LOT))
            ;

            CreateMap<LandmarkModel, Landmark>()
                .ForMember(dest => dest.LM_NAME, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LP_NUMBER, opt => opt.MapFrom(src => src.LPNumber))
                .ForMember(dest => dest.BIN_NUMBER, opt => opt.MapFrom(src => src.BinNumber))
                .ForMember(dest => dest.BBL, opt => opt.MapFrom(src => src.BBL))
                .ForMember(dest => dest.LM_TYPE, opt => opt.MapFrom(src => src.ObjectType))
                .ForMember(dest => dest.LOT, opt => opt.MapFrom(src => src.Lot))
                .ForMember(dest => dest.BLOCK, opt => opt.MapFrom(src => src.Block))
                .ForMember(dest => dest.DESIG_ADDR, opt => opt.MapFrom(src => src.DesignatedAddress))
                .ForMember(dest => dest.PLUTO_ADDR, opt => opt.MapFrom(src => src.PlutoAddress))
                .ForMember(dest => dest.MOST_CURRE, opt => opt.MapFrom(src => src.IsCurrent))
                .ForMember(dest => dest.VACANT_LOT, opt => opt.MapFrom(src => src.IsVacantLot))
            ;
        }
    }
}

