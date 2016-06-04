using CoreDataStore.Data.Infrastructure;
using CoreDataStore.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CoreDataStore.Data.Sqlite.Repositories
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
