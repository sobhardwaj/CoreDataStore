using System.Collections.Generic;
using System.Threading.Tasks;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Interfaces
{
    public interface IPlutoService
    {
        List<PlutoModel> GetPluto(string lpcNumber);

        Task<List<PlutoModel>> GetPlutoAsync(string lpcNumber);
    }
}
