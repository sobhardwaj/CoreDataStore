using CoreDataStore.Data.Filters.Base;

namespace CoreDataStore.Data.Filters
{
    public class LandmarkRequest : RequestBase
    {
        /// <summary>
        /// LPC Number
        /// </summary>
        public string LpcNumber { get; set; }
    }
}
