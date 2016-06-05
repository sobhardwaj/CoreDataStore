using CoreDataStore.Data.Sqlite.Filters.Base;

namespace CoreDataStore.Data.Filters
{
    public class LandmarkRequest : RequestBase
    {
        /// <summary>
        /// LPC Number
        /// </summary>
        public string LPCNumber { get; set; }

    }
}
