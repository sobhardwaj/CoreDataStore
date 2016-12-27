using AutoMapper;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Mappings
{
    public class PlutoMapping : Profile
    {
        public PlutoMapping() : base("PlutoMapping")
        {
            CreateMap<Pluto, PlutoModel>();
            CreateMap<PlutoModel, Pluto>();
        }
    }
}
