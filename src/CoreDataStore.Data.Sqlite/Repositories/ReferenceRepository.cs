using System.Collections.Generic;
using CoreDataStore.Domain.Interfaces;

namespace CoreDataStore.Data.Sqlite.Repositories
{
    public class ReferenceRepository : IReferenceRepository
    {
        public List<ReferenceType> GetObjectTypes()
        {
            var list = new List<ReferenceType>();

            list.Add(new ReferenceType {Name = "", Value = ""});  //"Individual Landmark");
            list.Add(new ReferenceType { Name = "", Value = "" });
            list.Add(new ReferenceType { Name = "", Value = "" });
            list.Add(new ReferenceType { Name = "", Value = "" });

            return list;   
        }
    }


}
