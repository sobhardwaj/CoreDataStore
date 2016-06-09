using CoreDataStore.Data.Infrastructure;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Domain.Entities;

namespace CoreDataStore.Data.SqlServer.Repositories
{
    public class LPCReportRepository : EntityBaseRepository<LPCReport>, ILPCReportRepository
    {
        public LPCReportRepository(NYCLandmarkContext context)
            : base(context)
        { }

        //private readonly NYCLandmarkContext _context;
        //private readonly ILogger _logger;

        //public LPCReportRepository(NYCLandmarkContext context, ILoggerFactory loggerFactory)
        //{
        //    _context = context;
        //    _logger = loggerFactory.CreateLogger("ILPCReportRepository");
        //}



    }
}
