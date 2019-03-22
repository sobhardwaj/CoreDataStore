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
                new ReferenceType {Name = "Individual Landmark", Value = "Individual Landmark"},
                new ReferenceType {Name = "Historic District", Value = "Historic District"},
                new ReferenceType {Name = "Scenic Landmark", Value = "Scenic Landmark"},
                new ReferenceType {Name = "Interior Landmark", Value = "Interior Landmark"}
            };

            return list;

        }
    }
}
