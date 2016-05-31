using System.Collections.Generic;
using System.Linq;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace CoreDataStore.Data.Sqlite.Repositories
{
    public class LPCReportRepository : ILPCReportRepository
    {
        private readonly NYCLandmarkContext _context;
        private readonly ILogger _logger;

        public LPCReportRepository(NYCLandmarkContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("ILPCReportRepository");
        }

        public List<LPCReport> GetAll()
        {
            _logger.LogCritical("Return All Records");
            return _context.LPCReports.ToList();
        }

    }
}
