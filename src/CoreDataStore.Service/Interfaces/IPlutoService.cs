using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Interfaces
{
    public interface IPlutoService
    {
        List<PlutoModel> GetPluto(string lpcNumber);
    }
}
