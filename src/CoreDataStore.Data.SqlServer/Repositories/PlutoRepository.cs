using CoreDataStore.Data.Infrastructure;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Domain.Entities;

namespace CoreDataStore.Data.SqlServer.Repositories
{
    public class PlutoRepository : EntityBaseRepository<Pluto>, IPlutoRepository
    {
        public PlutoRepository(NYCLandmarkContext context)
            : base(context)
        {
        }
    }
}
