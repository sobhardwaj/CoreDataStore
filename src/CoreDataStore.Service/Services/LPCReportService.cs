using System.Collections.Generic;
using System.Linq;
using CoreDataStore.Data.Sqlite.Filters;
using CoreDataStore.Data.Sqlite.Repositories.Abstract;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Service.Interfaces;

namespace CoreDataStore.Service.Services
{
    public class LPCReportService : ILPCReportService
    {
        private readonly ILPCReportRepository _lpcReportRepository;

        public LPCReportService(ILPCReportRepository lpcReportRepository)
        {
            this._lpcReportRepository = lpcReportRepository;
        }

        public List<LPCReport> GetLPCReports()
        {
           return _lpcReportRepository.GetAll().ToList();
        }

        public List<LPCReport> GetLPCReports(LPCReportRequest request, out int totalCount)
        {
            var query = _lpcReportRepository.GetAll();

            if (!string.IsNullOrEmpty(request.Borough))
                query = query.Where(r => r.Borough == request.Borough);

            if (!string.IsNullOrEmpty(request.ObjectType))
                query = query.Where(r => r.ObjectType == request.ObjectType);

            var results = query.ToList();
            totalCount = results.Count();

            // return Mapper.Map<IEnumerable<LPCReport>, IEnumerable<LPCReportModel>>(results).ToList();
            return results.Skip(request.PageSize * (request.Page - 1)).Take(request.PageSize).ToList(); 
        }

    }
}
