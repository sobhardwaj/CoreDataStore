using AutoMapper;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Service.Models;
using System;

namespace CoreDataStore.Service.Mappings
{
    public class LPCReportMapping : Profile
    {
        public LPCReportMapping()
            : base("LPCReportMapping")
        {
            CreateMap<LPCReport, LPCReportModel>();

            CreateMap<LPCReportModel, LPCReport>()
                 .ForMember(dest => dest.LPCId, opt => opt.Ignore())
                 .ForMember(dest => dest.LPNumber, opt => opt.Ignore())
                 .ForMember(dest => dest.PhotoStatus, opt => opt.Ignore())
                 .ForMember(dest => dest.PhotoURL, opt => opt.Ignore())
                 .ForMember(dest => dest.Landmarks, opt => opt.Ignore())
                 ;
        }
    }
}
