using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CoreDataStore.Data.Postgre.Test.Helpers
{
    public class TemporaryDbContextFactory : IDbContextFactory<NYCLandmarkContext>
    {
        //http://benjii.me/2016/05/dotnet-ef-migrations-for-asp-net-core/
        public NYCLandmarkContext Create()
        {
            var builder = new DbContextOptionsBuilder<NYCLandmarkContext>();
            builder.UseNpgsql("User ID=postgres; Password=password;  Server=localhost;Port=5432;Database=nyclandmarks;Integrated Security=true;Pooling=true;"
                , b => b.MigrationsAssembly(GetType().GetTypeInfo().Assembly.GetName().Name));

            return new NYCLandmarkContext(builder.Options);
        }

    }
}
