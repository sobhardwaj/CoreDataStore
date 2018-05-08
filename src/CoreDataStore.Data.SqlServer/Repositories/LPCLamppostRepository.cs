using CoreDataStore.Data.Infrastructure;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Domain.Entities;

namespace CoreDataStore.Data.SqlServer.Repositories
{
    public class LpcLamppostRepository : EntityBaseRepository<LPCLamppost>, ILpcLamppostRepository
    {
        public LpcLamppostRepository(NYCLandmarkContext context) 
            : base(context)
        {
        }

        public void Dispose()
        {
        }
    }
}
