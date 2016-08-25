using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CoreDataStore.Common.Helpers;
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
            var predicate = PredicateBuilder.True<Landmark>();

            //HardCoded 
            predicate = predicate.And(x => x.LP_NUMBER == "LP-01831");

            totalCount = _landmarktRepository.FindBy(predicate).Count();

            var results = _landmarktRepository.FindBy(predicate).Skip(request.PageSize * (request.Page - 1)).Take(request.PageSize).ToList();
            return Mapper.Map<List<Landmark>, List<LandmarkModel>>(results).ToList();

        }

    }








}
