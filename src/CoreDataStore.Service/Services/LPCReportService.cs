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
using Microsoft.EntityFrameworkCore;

namespace CoreDataStore.Service.Services
{
    public class LpcReportService : ILpcReportService
    {
        private readonly ILpcReportRepository _lpcReportRepository;

        public LpcReportService(ILpcReportRepository lpcReportRepository)
        {
            this._lpcReportRepository = lpcReportRepository;
        }

        public LpcReportModel GetLPCReport(int id)
        {
            var query = _lpcReportRepository.GetSingle(id);

            return Mapper.Map<LpcReport, LpcReportModel>(query);
        }

        public List<LpcReportModel> GetLPCReports()
        {
            var results = _lpcReportRepository.GetAll().ToList();
            return Mapper.Map<IEnumerable<LpcReport>, IEnumerable<LpcReportModel>>(results).ToList();
        }

        public LpcReportModel UpdateLPCReport(LpcReportModel model)
        {
            var report = _lpcReportRepository.GetSingle(model.Id);
            Mapper.Map(model, report);

            _lpcReportRepository.Edit(report);
            _lpcReportRepository.Commit();

            var results = _lpcReportRepository.GetSingle(model.Id);
            return Mapper.Map<LpcReport, LpcReportModel>(results);
        }

        public PagedResultModel<LpcReportModel> GetLPCReports(LpcReportRequest request)
        {
            var predicate = PredicateBuilder.True<LpcReport>();

            if (!string.IsNullOrEmpty(request.Neighborhood))
                predicate = predicate.And(x => x.LPCLocation.Neighborhood == request.Neighborhood);

            if (!string.IsNullOrEmpty(request.Borough))
                predicate = predicate.And(x => x.Borough == request.Borough);

            if (!string.IsNullOrEmpty(request.ObjectType))
                predicate = predicate.And(x => x.ObjectType == request.ObjectType);

            var sortModel = new SortModel
            {
                SortColumn = !string.IsNullOrEmpty(request.SortColumn) ? request.SortColumn : null,
                SortOrder = !string.IsNullOrEmpty(request.SortOrder) ? request.SortOrder : null
            };

            var sortingList = new List<SortModel> { sortModel };

            int totalCount = _lpcReportRepository.GetCount(predicate);

            var results = _lpcReportRepository
                .GetPage(predicate, request.PageSize * (request.Page - 1), request.PageSize, sortingList).Include(x => x.LPCLocation);

            var modelData = Mapper.Map<IEnumerable<LpcReport>, IEnumerable<LpcReportModel>>(results).ToList();
            return new PagedResultModel<LpcReportModel>
            {
                Total = totalCount,
                Page = request.Page,
                Limit = request.PageSize,
                Results = modelData,
            };
        }
    }
}
