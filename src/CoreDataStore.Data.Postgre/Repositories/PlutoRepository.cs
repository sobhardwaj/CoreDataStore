using System;
using System.Collections.Generic;
using System.Linq;
using CoreDataStore.Data.Infrastructure;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Domain.Entities;

namespace CoreDataStore.Data.Postgre.Repositories
{
    public class PlutoRepository : EntityBaseRepository<Pluto>, IPlutoRepository
    {
        private readonly NycLandmarkContext _context;

        public PlutoRepository(NycLandmarkContext context)
            : base(context)
        {
            _context = context;
        }

        public List<Pluto> GetPluto(string lpcNumber)
        {
            var results = (from l in _context.Landmarks
                           join p in _context.Pluto on
                           new { Lot = l.LOT, Block = l.BLOCK, Borough = l.BoroughID }
                           equals
                           new { p.Lot, p.Block, p.Borough }
                           where l.LP_NUMBER == lpcNumber
                           select p).Distinct().ToList();

            return results;
        }

        public int GetPlutoCount(string lpcNumber)
        {
            return GetPluto(lpcNumber).Count;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _context?.Dispose();
        }
    }
}
