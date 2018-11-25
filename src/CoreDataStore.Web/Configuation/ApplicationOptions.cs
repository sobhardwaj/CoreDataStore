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
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class ConnectionStrings
    {
        /// <summary>
        /// Sqlite ConnectionString.
        /// </summary>
        public string Sqlite { get; set; }

        /// <summary>
        /// SqlServer ConnectionString.
        /// </summary>
        public string SqlServer { get; set; }

        /// <summary>
        /// Postgres SQL ConnectionString.
        /// </summary>
        public string PostgreSql { get; set; }
    }
}
