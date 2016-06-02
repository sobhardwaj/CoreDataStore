using System.Collections.Generic;

namespace CoreDataStore.Domain.Interfaces
{
    public interface IReferenceRepository
    {
        List<ReferenceType> GetObjectTypes();

    }

    public class ReferenceType
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }


}
