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
            CreateMap<Landmark, LandmarkModel>();

            CreateMap<LandmarkModel, Landmark>();
        }
    }
}

