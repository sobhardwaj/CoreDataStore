using System.Collections.Generic;
using CoreDataStore.Domain.Entities;

namespace CoreDataStore.Domain.Interfaces
{
    public interface IDataAccessProvider
    {
        void Delete(long id);

        DataEventRecord Get(long id);

        List<DataEventRecord> GetAll();

        void Post(DataEventRecord dataEventRecord);

        void Put(long id, DataEventRecord dataEventRecord);
    }
}