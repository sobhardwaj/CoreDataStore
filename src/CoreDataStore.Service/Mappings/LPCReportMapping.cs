using AutoMapper;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Service.Models;
using System;

namespace CoreDataStore.Service.Mappings
{
    public class LPCReportMapping : Profile
    {
        [Obsolete]
        protected override void Configure()
        {
            CreateMap<LPCReport, LPCReportModel>();
        }
    }

}
