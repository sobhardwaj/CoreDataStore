using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CoreDataStore.Data.Extensions;
using CoreDataStore.Data.Filters;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.Sqlite.Filters;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Service.Interfaces;
using CoreDataStore.Service.Models;


namespace CoreDataStore.Service.Services
{
    public class LPCReportService : ILPCReportService
    {
        private readonly ILPCReportRepository _lpcReportRepository;

        public LPCReportService(ILPCReportRepository lpcReportRepository)
        {
            this._lpcReportRepository = lpcReportRepository;
        }

        public List<LPCReportModel> GetLPCReports()
        {
           var results = _lpcReportRepository.GetAll().ToList();
           return Mapper.Map<IEnumerable<LPCReport>, IEnumerable<LPCReportModel>>(results).ToList();
        }

        public List<LPCReportModel> GetLPCReports(LPCReportRequest request, out int totalCount)
        {
            var query = _lpcReportRepository.GetAll();

            if (!string.IsNullOrEmpty(request.Borough))
                query = query.Where(r => r.Borough == request.Borough);

            if (!string.IsNullOrEmpty(request.ObjectType))
                query = query.Where(r => r.ObjectType == request.ObjectType);

            var sortModel = new SortModel
            {
               SortColumn = !string.IsNullOrEmpty(request.SortColumn) ? request.SortColumn : null,
               SortOrder = !string.IsNullOrEmpty(request.SortColumn) ? request.SortColumn : null
            };

            var results = query.ToList();  //  OrderBy(sortModel).ToList();


            totalCount = results.Count();
            results = results.Skip(request.PageSize * (request.Page - 1)).Take(request.PageSize).ToList();

            return Mapper.Map<IEnumerable<LPCReport>, IEnumerable<LPCReportModel>>(results).ToList(); 
        }

    }
}
