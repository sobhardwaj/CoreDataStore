namespace CoreDataStore.Web.Configuration
{
    /// <summary>
    /// Application configuration Options.
    /// </summary>
    public class ApplicationOptions
    {
        /// <summary>
        /// Db ConnectionStrings.
        /// </summary>
        public ConnectionStrings ConnectionStrings { get; set; }

        /// <summary>
        /// Graylog Syslog Server
        /// </summary>
        public Graylog Graylog { get; set; }

    }

    /// <summary>
    /// ConnectionStrings
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

    public class Graylog
    {
        public string Host { get; set; }

        public string LogSource { get; set; }
    }
}
