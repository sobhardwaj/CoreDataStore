using System;
using Microsoft.EntityFrameworkCore;

namespace CoreDataStore.Data.Postgre.EF
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
                    .UseNpgsql(@"User ID=postgres; Password=password;Server=192.168.99.100;Port=5432;Database=nyclandmarks_ef;Integrated Security=true;Pooling=true;");
            }
        }
    }
}
