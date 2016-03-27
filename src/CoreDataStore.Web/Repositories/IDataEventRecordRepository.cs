using System.Collections.Generic;
using CoreDataStore.Web.Model;
using Microsoft.AspNet.Mvc;

namespace CoreDataStore.Web.Repositories
{
    public interface IDataEventRecordRepository
    {
        void Delete(long id);

        DataEventRecord Get(long id);

        List<DataEventRecord> GetAll();

        void Post(DataEventRecord dataEventRecord);

        void Put(long id, [FromBody] DataEventRecord dataEventRecord);
    }
}
