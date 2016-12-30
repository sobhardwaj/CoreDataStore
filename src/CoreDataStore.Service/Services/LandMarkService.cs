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
    public class LandmarkService : ILandmarkService
    {
        private readonly ILandmarkRepository  _landmarktRepository;

        public LandmarkService(ILandmarkRepository landmarktRepository)
        {
            this._landmarktRepository = landmarktRepository;
        }

        public PagedResultModel<LandmarkModel> GetLandmarks(LandmarkRequest request)
        {
            var predicate = PredicateBuilder.True<Landmark>();

            if (!string.IsNullOrEmpty(request.LPCNumber))
                predicate = predicate.And(x => x.LP_NUMBER == request.LPCNumber);

            var sortModel = new SortModel
            {
                SortColumn = !string.IsNullOrEmpty(request.SortColumn) ? request.SortColumn : null,
                SortOrder = !string.IsNullOrEmpty(request.SortOrder) ? request.SortOrder : null
            };

            var sortingList = new List<SortModel>();
            sortingList.Add(sortModel);

            int totalCount = _landmarktRepository.FindBy(predicate).Count();

            var results = _landmarktRepository
                .GetPage(predicate, request.PageSize * (request.Page - 1), request.PageSize, sortingList);

            var modelData = Mapper.Map<IEnumerable<Landmark>, IEnumerable<LandmarkModel>>(results).ToList();

            var pagedResult = new PagedResultModel<LandmarkModel>
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
