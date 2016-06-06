using CoreDataStore.Web.Filters.Base;

namespace CoreDataStore.Web.Filters
{
    public class LPCReportRequestModel : RequestModel
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
