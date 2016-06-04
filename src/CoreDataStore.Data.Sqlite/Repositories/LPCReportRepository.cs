using CoreDataStore.Data.Sqlite.Repositories.Abstract;
using CoreDataStore.Domain.Entities;

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

        //public List<LPCReport> GetAll()
        //{
        //    _logger.LogCritical("Return All Records");
        //    return _context.LPCReports.OrderBy(x => x.LPNumber).ToList();
        //}

    }
}
