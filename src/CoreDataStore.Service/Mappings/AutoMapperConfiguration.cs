using AutoMapper;

namespace CoreDataStore.Service.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<LPCReportMapping>();
                x.AddProfile<LandmarkMapping>();
                x.AddProfile<PlutoMapping>();
            });
        }
    }
}
