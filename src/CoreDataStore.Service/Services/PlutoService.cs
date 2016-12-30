using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Service.Interfaces;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Services
{
    public class PlutoService : IPlutoService
    {
        private readonly IPlutoRepository _plutoRepository;

        public PlutoService(IPlutoRepository plutoRepository)
        {
            this._plutoRepository = plutoRepository;
        }

        public List<PlutoModel> GetPluto(string lpcNumber)
        {
            var results = _plutoRepository.FindBy(x => x.Landmark.LP_NUMBER == lpcNumber).ToList();
            return Mapper.Map<IEnumerable<Pluto>, IEnumerable<PlutoModel>>(results).ToList();
        }
    }
}
