using System.Collections.Generic;

namespace CoreDataStore.Data.Sqlite.Filters.Base
{
    public abstract class RequestBase
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public List<string> FieldsList { get; set; }

        public string SortColumn { get; set; }

        public string SortOrder { get; set; }
    }
}
