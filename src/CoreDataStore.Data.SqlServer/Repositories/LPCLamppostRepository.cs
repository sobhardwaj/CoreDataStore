using CoreDataStore.Data.Infrastructure;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Domain.Entities;

namespace CoreDataStore.Data.SqlServer.Repositories
{
    public class LPCLamppostRepository : EntityBaseRepository<LPCLamppost>, ILPCLamppostRepository
    {
        public LPCLamppostRepository(NYCLandmarkContext context) 
            : base(context)
        {
        }
    }
}
