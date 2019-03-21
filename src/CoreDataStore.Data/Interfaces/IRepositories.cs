using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreDataStore.Data.Infrastructure;
using CoreDataStore.Domain.Entities;

namespace CoreDataStore.Data.Interfaces
{
    public interface ILandmarkRepository : IEntityBaseRepository<Landmark>, IDisposable { }

    public interface ILpcReportRepository : IEntityBaseRepository<LpcReport>, IDisposable { }

    public interface ILpcLocationRepository : IEntityBaseRepository<LpcLocation>, IDisposable { }

    public interface ILpcLamppostRepository : IEntityBaseRepository<LpcLamppost>, IDisposable { }

    public interface IPlutoRepository : IEntityBaseRepository<Pluto>, IDisposable
    {
        List<Pluto> GetPluto(string lpcNumber);

        Task<List<Pluto>> GetPlutoAsync(string lpcNumber);

        int GetPlutoCount(string lpcNumber);

        Task<int> GetPlutoCountAsync(string lpcNumber);
    }
}
