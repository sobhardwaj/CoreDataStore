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

        public LPCReportModel UpdateLPCReport(LPCReportModel model)
        {
            var report = _lpcReportRepository.GetSingle(model.Id);
            Mapper.Map(model, report);

            _lpcReportRepository.Edit(report);
            _lpcReportRepository.Commit();

            var results = _lpcReportRepository.GetSingle(model.Id);
            return Mapper.Map<LPCReport, LPCReportModel>(results);
        }

        public PagedResultModel<LPCReportModel> GetLPCReports(LPCReportRequest request)
        {
            var predicate = PredicateBuilder.True<LPCReport>();

            if (!string.IsNullOrEmpty(request.Borough))
                predicate = predicate.And(x => x.Borough == request.Borough);

            if (!string.IsNullOrEmpty(request.ObjectType))
                predicate = predicate.And(x => x.ObjectType == request.ObjectType);

            var sortModel = new SortModel
            {
                SortColumn = !string.IsNullOrEmpty(request.SortColumn) ? request.SortColumn : null,
                SortOrder = !string.IsNullOrEmpty(request.SortOrder) ? request.SortOrder : null
            };

            var sortingList = new List<SortModel>();
            sortingList.Add(sortModel);

            int totalCount = _lpcReportRepository.FindBy(predicate).Count();

            var results = _lpcReportRepository
                .GetPage(predicate, request.PageSize * (request.Page - 1), request.PageSize, sortingList);
            
            var modelData = Mapper.Map<IEnumerable<LPCReport>, IEnumerable<LPCReportModel>>(results).ToList();

            var pagedResult = new PagedResultModel<LPCReportModel>
            {
                Total = totalCount,
                Page = request.Page,
                Limit = request.PageSize,
                Results = modelData,
            };

            return pagedResult;
        }

    }
}
