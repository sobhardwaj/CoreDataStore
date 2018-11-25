using AutoMapper;

namespace CoreDataStore.Service.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static bool _isMappinginitialized;

        private static readonly object ThisLock = new object();

        public static void Configure()
        {
            lock (ThisLock)
            {
                if (!_isMappinginitialized)
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
}
