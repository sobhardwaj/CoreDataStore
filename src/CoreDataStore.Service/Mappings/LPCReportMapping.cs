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

            CreateMap<LPCReportModel, LPCReport>();
        }
    }
}
