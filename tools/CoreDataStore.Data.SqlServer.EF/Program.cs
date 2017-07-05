using Microsoft.EntityFrameworkCore;

namespace CoreDataStore.Data.SqlServer.EF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NycLandmarkContextMock())
            {
                db.Database.EnsureCreated();
            }
        }

        public class NycLandmarkContextMock : NYCLandmarkContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder
                    .UseSqlServer(@"Data Source=.;Initial Catalog=NycLandmarks_EF;Integrated Security=True");
            }
        }
    }
}
