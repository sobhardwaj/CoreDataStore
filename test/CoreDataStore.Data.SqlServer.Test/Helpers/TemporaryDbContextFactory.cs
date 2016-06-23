using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.DotNet.Cli.Utils.CommandParsing;

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

            Console.WriteLine(AppContext.BaseDirectory);
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot Configuration = configBuilder.Build();
            
            builder.UseSqlServer(@"Data Source=.;Initial Catalog=NycLandmarks;Integrated Security=True" //Configuration["connectionString:SqlServer"]
                , b => b.MigrationsAssembly(GetType().GetTypeInfo().Assembly.GetName().Name));

            return new NYCLandmarkContext(builder.Options);
        }

    }
}
