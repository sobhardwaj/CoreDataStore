using System.Collections.Generic;

namespace CoreDataStore.Data.Filters.Base
{
    public abstract class RequestBase
    {
        /// <summary>
        ///  Page
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        ///  Page Size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Fields List
        /// </summary>
        public List<string> FieldsList { get; set; }

        /// <summary>
        ///  Sort Column
        /// </summary>
        public string SortColumn { get; set; }

        /// <summary>
        /// Sort Order
        /// </summary>
        public string SortOrder { get; set; }
    }
}
