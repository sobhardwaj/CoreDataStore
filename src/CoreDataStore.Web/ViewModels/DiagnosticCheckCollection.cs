using System.Collections.Generic;

namespace CoreDataStore.Web.ViewModels
{
    public class DiagnosticCheckCollection
    {
        public string CollectionName { get; set; }

        public bool? Passed { get; set; }

        public IEnumerable<DiagnosticCheckResult> Results { get; set; }

        public string Notes { get; set; }

    }
}
