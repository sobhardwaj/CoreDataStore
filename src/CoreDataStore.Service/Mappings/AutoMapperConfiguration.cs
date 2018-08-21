using AutoMapper;

namespace CoreDataStore.Service.Mappings
{
    public class AutoMapperConfiguration
    {
        public static bool _isMappinginitialized;

        public static void Configure()
        {
            if (_isMappinginitialized == false)
            {
                Mapper.Initialize(x =>
                {
                    x.AddProfile<LPCReportMapping>();
                    x.AddProfile<LandmarkMapping>();
                    x.AddProfile<PlutoMapping>();
                });
            }

            _isMappinginitialized = true;
        }
    }
}
