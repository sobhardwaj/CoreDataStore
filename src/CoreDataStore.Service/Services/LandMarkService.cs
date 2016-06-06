using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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


        public List<LandmarkModel> GetLandmarks(LandmarkRequest request, out int totalCount)
        {
            var query = _landmarktRepository.GetAll().Where(x => x.LP_NUMBER == "LP-00955");
            var results = query.ToList(); 

            totalCount = results.Count();
            results = results.Skip(request.PageSize * (request.Page - 1)).Take(request.PageSize).ToList();

            return Mapper.Map<IEnumerable<Landmark>, IEnumerable<LandmarkModel>>(results).ToList();
        }

    }

}
