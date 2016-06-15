using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CoreDataStore.Common.Helpers;
using CoreDataStore.Data.Extensions;
using CoreDataStore.Data.Filters;
using CoreDataStore.Data.Interfaces;
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

        public LPCReportModel GetLPCReport(int id)
        {
            var query = _lpcReportRepository.GetSingle(id);

            return Mapper.Map<LPCReport, LPCReportModel>(query);
        }

        public List<LPCReportModel> GetLPCReports()
        {
           var results = _lpcReportRepository.GetAll().ToList();
           return Mapper.Map<IEnumerable<LPCReport>, IEnumerable<LPCReportModel>>(results).ToList();
        }

        public List<LPCReportModel> GetLPCReports(LPCReportRequest request, out int totalCount)
        {
            var predicate = PredicateBuilder.True<LPCReport>();

            if (!string.IsNullOrEmpty(request.Borough))
                predicate = predicate.And(x => x.Borough == request.Borough);

            if (!string.IsNullOrEmpty(request.ObjectType))
                predicate = predicate.And(x => x.ObjectType == request.ObjectType);

            var sortModel = new SortModel
            {
                SortColumn = !string.IsNullOrEmpty(request.SortColumn) ? request.SortColumn : null,
                SortOrder = !string.IsNullOrEmpty(request.SortColumn) ? request.SortColumn : null
            };

            totalCount = _lpcReportRepository.FindBy(predicate).Count();

            var results = _lpcReportRepository.FindBy(predicate).Skip(request.PageSize * (request.Page - 1)).Take(request.PageSize).ToList();
            return Mapper.Map<IEnumerable<LPCReport>, IEnumerable<LPCReportModel>>(results).ToList(); 
        }

    }
}
