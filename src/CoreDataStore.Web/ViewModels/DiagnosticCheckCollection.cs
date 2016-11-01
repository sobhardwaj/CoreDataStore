using System.Collections.Generic;

namespace CoreDataStore.Web.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class DiagnosticCheckCollection
    {
        /// <summary>
        /// 
        /// </summary>
        public string CollectionName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? Passed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<DiagnosticCheckResult> Results { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Notes { get; set; }

    }
}
