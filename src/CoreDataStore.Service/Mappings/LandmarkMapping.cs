using System;
using AutoMapper;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Mappings
{
    public class LandmarkMapping : Profile
    {
        public LandmarkMapping()
            : base("LandmarkMapping")
        {
            CreateMap<Landmark, LandmarkModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LM_NAME))
                .ForMember(dest => dest.LPNumber, opt => opt.MapFrom(src => src.LP_NUMBER))
                .ForMember(dest => dest.BBL, opt => opt.MapFrom(src => src.BBL))
                .ForMember(dest => dest.BoroughId, opt => opt.MapFrom(src => src.BoroughID))
                .ForMember(dest => dest.BinNumber, opt => opt.MapFrom(src => src.BIN_NUMBER))
                .ForMember(dest => dest.ObjectType, opt => opt.MapFrom(src => src.LM_TYPE))
                .ForMember(dest => dest.Lot, opt => opt.MapFrom(src => src.LOT))
                .ForMember(dest => dest.Block, opt => opt.MapFrom(src => src.BLOCK))
                .ForMember(dest => dest.DesignatedAddress, opt => opt.MapFrom(src => src.DESIG_ADDR))
                .ForMember(dest => dest.DesignatedDate, opt => opt.MapFrom(src => src.DESIG_DATE))
                .ForMember(dest => dest.CalendaredDate, opt => opt.MapFrom(src => src.CALEN_DATE))
                .ForMember(dest => dest.PlutoAddress, opt => opt.MapFrom(src => src.PLUTO_ADDR))
                .ForMember(dest => dest.HistoricDistrict, opt => opt.MapFrom(src => src.HIST_DISTR))
                .ForMember(dest => dest.PublicHearingDate, opt => opt.MapFrom(src => src.PUBLIC_HEA))
                .ForMember(dest => dest.OtherHearingDate, opt => opt.MapFrom(src => src.OTHER_HEAR))
                .ForMember(dest => dest.RecordType, opt => opt.MapFrom(src => src.NON_BLDG))
                .ForMember(dest => dest.PriorStatus, opt => opt.MapFrom(src => src.STATUS_NOT))
                .ForMember(dest => dest.LastAction, opt => opt.MapFrom(src => src.LAST_ACTIO))
                .ForMember(dest => dest.IsBuilding, opt => opt.MapFrom(src => src.COUNT_BLDG))
                .ForMember(dest => dest.IsSecondaryBuilding, opt => opt.MapFrom(src => src.SECND_BLDG))
                .ForMember(dest => dest.IsCurrent, opt => opt.MapFrom(src => src.MOST_CURRE))
                .ForMember(dest => dest.IsVacantLot, opt => opt.MapFrom(src => src.VACANT_LOT))
                .ForMember(dest => dest.LPCReport, opt => opt.Ignore())
            ;

            CreateMap<LandmarkModel, Landmark>()
                .ForMember(dest => dest.LM_NAME, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LP_NUMBER, opt => opt.MapFrom(src => src.LPNumber))
                .ForMember(dest => dest.BIN_NUMBER, opt => opt.MapFrom(src => src.BinNumber))
                .ForMember(dest => dest.BoroughID, opt => opt.MapFrom(src => src.BoroughId))
                .ForMember(dest => dest.BBL, opt => opt.MapFrom(src => src.BBL))
                .ForMember(dest => dest.LM_TYPE, opt => opt.MapFrom(src => src.ObjectType))
                .ForMember(dest => dest.LOT, opt => opt.MapFrom(src => src.Lot))
                .ForMember(dest => dest.BLOCK, opt => opt.MapFrom(src => src.Block))
                .ForMember(dest => dest.DESIG_ADDR, opt => opt.MapFrom(src => src.DesignatedAddress))
                .ForMember(dest => dest.DESIG_DATE, opt => opt.MapFrom(src => src.DesignatedDate))
                .ForMember(dest => dest.CALEN_DATE, opt => opt.MapFrom(src => src.CalendaredDate))
                .ForMember(dest => dest.PLUTO_ADDR, opt => opt.MapFrom(src => src.PlutoAddress))
                .ForMember(dest => dest.HIST_DISTR, opt => opt.MapFrom(src => src.HistoricDistrict))
                .ForMember(dest => dest.PUBLIC_HEA, opt => opt.MapFrom(src => src.PublicHearingDate))
                .ForMember(dest => dest.OTHER_HEAR, opt => opt.MapFrom(src => src.OtherHearingDate))
                .ForMember(dest => dest.LAST_ACTIO, opt => opt.MapFrom(src => src.LastAction))
                .ForMember(dest => dest.NON_BLDG, opt => opt.MapFrom(src => src.RecordType))
                .ForMember(dest => dest.STATUS_NOT, opt => opt.MapFrom(src => src.PriorStatus))
                .ForMember(dest => dest.COUNT_BLDG, opt => opt.MapFrom(src => src.IsBuilding))
                .ForMember(dest => dest.SECND_BLDG, opt => opt.MapFrom(src => src.IsSecondaryBuilding))
                .ForMember(dest => dest.MOST_CURRE, opt => opt.MapFrom(src => src.IsCurrent))
                .ForMember(dest => dest.VACANT_LOT, opt => opt.MapFrom(src => src.IsVacantLot))
                
                .ForMember(dest => dest.LPCReport, opt => opt.Ignore())
            ;
        }
    }
}

