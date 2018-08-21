using System.Collections.Generic;
using System.Linq;
using CoreDataStore.Data.Infrastructure;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Domain.Entities;

namespace CoreDataStore.Data.SqlServer.Repositories
{
    public class PlutoRepository : EntityBaseRepository<Pluto>, IPlutoRepository
    {
        private readonly NYCLandmarkContext _context;

        public PlutoRepository(NYCLandmarkContext context)
            : base(context)
        {
            this._context = context;
        }

        public List<Pluto> GetPluto(string lpcNumber)
        {
            var results = (from l in _context.Landmarks
                join p in _context.Pluto on
                new { Lot = l.LOT, Block = l.BLOCK, Borough = l.BoroughID }
                equals
                new { Lot = p.Lot, Block = p.Block, Borough = p.Borough }
                where l.LP_NUMBER == lpcNumber
                           select p).Distinct().ToList();

            return results;
        }

        public int GetPlutoCount(string lpcNumber)
        {
            var results = (from l in _context.Landmarks
                join p in _context.Pluto on
                new { Lot = l.LOT, Block = l.BLOCK, Borough = l.BoroughID }
                equals
                new { p.Lot, p.Block, p.Borough }
                where l.LP_NUMBER == lpcNumber
                select p).Count();

            return results;
        }

        public void Dispose()
        {
           // _context?.Dispose();
        }
    }
}
