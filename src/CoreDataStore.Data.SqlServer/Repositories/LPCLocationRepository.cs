using CoreDataStore.Data.Infrastructure;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Domain.Entities;

namespace CoreDataStore.Data.SqlServer.Repositories
{
    public class LPCLocationRepository : EntityBaseRepository<LPCLocation>, ILpcLocationRepository
    {
        public LPCLocationRepository(NYCLandmarkContext context)
            : base(context)
        { }

        public void Dispose()
        {
        }
    }
}
