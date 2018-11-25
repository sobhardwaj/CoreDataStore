using System.Collections.Generic;
using CoreDataStore.Domain.Interfaces;

namespace CoreDataStore.Data.Sqlite.Repositories
{
    public class ReferenceRepository : IReferenceRepository
    {
        public List<ReferenceType> GetObjectTypes()
        {
            var list = new List<ReferenceType>
            {
                new ReferenceType {Name = "", Value = ""},
                new ReferenceType {Name = "", Value = ""},
                new ReferenceType {Name = "", Value = ""},
                new ReferenceType {Name = "", Value = ""}
            };

            return list;
        }
    }
}
