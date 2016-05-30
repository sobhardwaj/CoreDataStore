using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDataStore.Domain.Entities;

namespace CoreDataStore.Domain.Interfaces
{
    public interface IBlogRepository
    {
        List<Blog> GetAll();


    }
}
