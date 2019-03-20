using System.Collections.Generic;
using System.Linq;
using CoreDataStore.Domain.Entities;
using GenFu;

namespace CoreDataStore.Service.Test.Data
{
    public static class PlutoDataSource
    {
        public static Pluto GetPlutoItem()
        {
            return GetPlutoList(1).First();
        }

        public static List<Pluto> GetPlutoList(int count)
        {
            var lat = new List<decimal> { 41.23m, 44.56m, 47.89m };
            var lon = new List<decimal> { -71.23m, -74.56m, -71.89m };

            GenFu.GenFu.Configure<Pluto>()
                .Fill(p => p.OwnerName)
                .Fill(p => p.Address).AsAddress()
                .Fill(p => p.ZipCode)
                .Fill(p => p.Latitude).WithRandom(lat)
                .Fill(p => p.Longitude).WithRandom(lon);

            return GenFu.GenFu.ListOf<Pluto>(100);
        }
    }
}
