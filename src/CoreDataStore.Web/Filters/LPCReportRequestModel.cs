using CoreDataStore.Web.Filters.Base;

namespace CoreDataStore.Web.Filters
{
    /// <summary>
    /// 
    /// </summary>
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


        /// <summary>
        /// Parent Styles List Comma Separated 
        /// </summary>
        public string ParentStyles { get; set; }

    }
}
