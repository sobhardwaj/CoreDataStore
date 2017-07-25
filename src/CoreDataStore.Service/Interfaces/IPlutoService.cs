using System.Collections.Generic;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Interfaces
{
    public interface IPlutoService
    {
        List<PlutoModel> GetPluto(string lpcNumber);
    }
}
