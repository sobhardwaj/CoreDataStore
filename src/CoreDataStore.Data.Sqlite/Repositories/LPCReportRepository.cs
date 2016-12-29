using CoreDataStore.Data.Infrastructure;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Domain.Entities;

namespace CoreDataStore.Data.Sqlite.Repositories
{
    public class LPCReportRepository : EntityBaseRepository<LPCReport>, ILPCReportRepository
    {
        public LPCReportRepository(NYCLandmarkContext context)
            : base(context)
        { }

    }
}
