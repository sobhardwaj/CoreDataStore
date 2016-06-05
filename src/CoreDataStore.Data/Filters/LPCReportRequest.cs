using CoreDataStore.Data.Sqlite.Filters.Base;

namespace CoreDataStore.Data.Filters
{
    public class LPCReportRequest : RequestBase
    {
        /// <summary>
        /// Object Type
        /// </summary>
        public string ObjectType { get; set; }


        /// <summary>
        /// Borough
        /// </summary>
        public string Borough { get; set; }

    }
}
