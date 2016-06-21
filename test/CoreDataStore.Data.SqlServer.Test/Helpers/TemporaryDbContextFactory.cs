using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CoreDataStore.Data.SqlServer.Test.Helpers
{
    public class TemporaryDbContextFactory : IDbContextFactory<NYCLandmarkContext>
    {
        //http://benjii.me/2016/05/dotnet-ef-migrations-for-asp-net-core/
        //https://github.com/jerriep/Aspnet5DbContextTesting/blob/master/test/Aspnet5DbContextTesting.Tests/ProductsControllerTests.cs

#warning "Remove Hardcoded DB Connection String"


        public NYCLandmarkContext Create()
        {
            var builder = new DbContextOptionsBuilder<NYCLandmarkContext>();

            builder.UseSqlServer(@"Data Source=DESKTOP-76B3NIJ;Initial Catalog=NycLandmarks;Integrated Security=True"
                , b => b.MigrationsAssembly(GetType().GetTypeInfo().Assembly.GetName().Name));

            return new NYCLandmarkContext(builder.Options);
        }

    }
}
