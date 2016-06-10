using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CoreDataStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq;

namespace CoreDataStore.Data.Postgre.Test.Helpers
{
    public class TemporaryDbContextFactory : IDbContextFactory<NYCLandmarkContext>
    {
        //http://benjii.me/2016/05/dotnet-ef-migrations-for-asp-net-core/
        //https://github.com/jerriep/Aspnet5DbContextTesting/blob/master/test/Aspnet5DbContextTesting.Tests/ProductsControllerTests.cs


        public NYCLandmarkContext Create()
        {
            var builder = new DbContextOptionsBuilder<NYCLandmarkContext>();
            builder.UseNpgsql(
                "User ID=postgres; Password=password;  Server=localhost;Port=5432;Database=nyclandmarks;Integrated Security=true;Pooling=true;"
                , b => b.MigrationsAssembly(GetType().GetTypeInfo().Assembly.GetName().Name));

            return new NYCLandmarkContext(builder.Options);
        }




     

    }

}
