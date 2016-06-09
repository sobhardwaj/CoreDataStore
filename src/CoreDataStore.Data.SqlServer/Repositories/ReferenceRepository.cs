using System.Collections.Generic;
using CoreDataStore.Domain.Interfaces;

namespace CoreDataStore.Data.SqlServer.Repositories
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


            //list.Add("Historic District");
            //list.Add("Scenic Landmark");
            //list.Add("Interior Landmark");

            return list;
   
        }
    }


}
