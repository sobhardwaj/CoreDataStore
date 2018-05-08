using System;
using System.Collections.Generic;
using CoreDataStore.Data.Infrastructure;
using CoreDataStore.Domain.Entities;

namespace CoreDataStore.Data.Interfaces
{
    public interface ILandmarkRepository : IEntityBaseRepository<Landmark>, IDisposable { }

    public interface ILpcReportRepository : IEntityBaseRepository<LPCReport>, IDisposable { }

    public interface ILpcLocationRepository : IEntityBaseRepository<LPCLocation>, IDisposable { }

    public interface ILpcLamppostRepository : IEntityBaseRepository<LPCLamppost>, IDisposable { }

    public interface IPlutoRepository : IEntityBaseRepository<Pluto>, IDisposable
    {
        List<Pluto> GetPluto(string lpcNumber);
        int GetPlutoCount(string lpcNumber);
    }

}
