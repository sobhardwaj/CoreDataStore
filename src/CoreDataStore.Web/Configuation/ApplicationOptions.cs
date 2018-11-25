namespace CoreDataStore.Web.Configuation
{
    /// <summary>
    /// Application configuration Options.
    /// </summary>
    public class ApplicationOptions
    {
        /// <summary>
        ///
        /// </summary>
        public HttpLogging HttpLogging { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class HttpLogging
    {
        public bool Enabled { get; set; }

        public string ConnectionString { get; set; }

        public string CollectionName { get; set; }

        public string Path { get; set; }
    }
}
