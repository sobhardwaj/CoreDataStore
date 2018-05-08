﻿using System.IO;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.SqlServer.Repositories;
using CoreDataStore.Service.Interfaces;
using CoreDataStore.Service.Mappings;
using CoreDataStore.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CoreDataStore.Data.SqlServer.Test.Services
{

    public class LandmarkServiceTest
    {
        private readonly ILandmarkService _landmarkService;

        public LandmarkServiceTest()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

            var dbonnection = builder.GetConnectionString("SqlServer");

            var serviceProvider = new ServiceCollection()
                .AddDbContext<NYCLandmarkContext>(options => options.UseSqlServer(dbonnection))
                .AddScoped<ILandmarkRepository, LandmarkRepository>()
                .AddScoped<ILandmarkService, LandmarkService>()
                .BuildServiceProvider();

            serviceProvider.GetRequiredService<NYCLandmarkContext>();
            serviceProvider.GetRequiredService<ILandmarkRepository>();

            _landmarkService = serviceProvider.GetRequiredService<ILandmarkService>();

            AutoMapperConfiguration.Configure();
        }


        //[Fact, Trait("Category", "Intergration")]
        //public void Can_Get_Street_List()
        //{
        //    string lpNumber = "LP-02039";

        //    var results = _landmarkService.GetLandmarkStreets(lpNumber);
        //    Assert.NotNull(results);
        //}

    }
}
