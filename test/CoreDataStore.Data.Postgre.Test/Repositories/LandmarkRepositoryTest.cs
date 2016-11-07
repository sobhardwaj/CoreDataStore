using System;
using System.Collections.Generic;
using System.Linq;
using CoreDataStore.Common.Helpers;
using CoreDataStore.Data.Extensions;
using CoreDataStore.Data.Filters;
using CoreDataStore.Data.Helpers;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.Postgre.Repositories;
using CoreDataStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CoreDataStore.Data.Postgre.Test.Repositories
{
    public class LandmarkRepositoryTest
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILandmarkRepository landmarkRepository;
        private readonly NYCLandmarkContext dbContext;

        public LandmarkRepositoryTest()
        {
            var services = new ServiceCollection();

            services.AddDbContext<NYCLandmarkContext>(options =>
            options.UseNpgsql(@"User ID=nyclandmarks;Password=nyclandmarks;Server=192.168.99.100;Port=5432;Database=nyclandmarks;Integrated Security=true;Pooling=true;"));

            services.AddScoped<ILandmarkRepository, LandmarkRepository>();
            serviceProvider = services.BuildServiceProvider();

            dbContext = serviceProvider.GetRequiredService<NYCLandmarkContext>();
            landmarkRepository = serviceProvider.GetRequiredService<ILandmarkRepository>();
        }

        [Fact(Skip = "ci test")]
        public void Can_Load_Landmarks()
        {
            int batchSize = 1000;

            var landmarks = DataLoader.LoadLandmarks(@"./../../data/Landmarks.csv").ToList();
            foreach (var list in landmarks.Batch(batchSize))
            {
                dbContext.Landmarks.AddRange(list);
                dbContext.SaveChanges();
            }
        }

        //[Fact]
        [Fact(Skip = "ci test")]
        public void Can_Get_Landmark()
        {
            var id = 100;
            var result = landmarkRepository.GetSingle(id);
            Assert.NotNull(result);
        }


        [Fact(Skip = "ci test")]
        //[Fact]
        public void Can_Get_Filtered_Paging_List()
        {
            var predicate = PredicateBuilder.True<Landmark>();
            var request = new LandmarkRequest() 
            {
                PageSize = 20,
                Page = 1,
            };

            var sortModel = new SortModel
            {
                SortColumn = !string.IsNullOrEmpty(request.SortColumn) ? request.SortColumn : null,
                SortOrder = !string.IsNullOrEmpty(request.SortOrder) ? request.SortOrder : null
            };

            var sortingList = new List<SortModel>();
            sortingList.Add(sortModel);

            var results = landmarkRepository
                .GetPage(predicate, request.PageSize * (request.Page - 1), request.PageSize, sortingList);

            Assert.NotNull(results);

        }
    }
}
