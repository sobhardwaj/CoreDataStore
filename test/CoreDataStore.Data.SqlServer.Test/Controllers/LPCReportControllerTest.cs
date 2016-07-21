using System;
using System.Collections.Generic;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.SqlServer.Repositories;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Service.Interfaces;
using CoreDataStore.Service.Mappings;
using CoreDataStore.Service.Models;
using CoreDataStore.Service.Services;
using CoreDataStore.Web.Controllers;
using CoreDataStore.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace CoreDataStore.Data.SqlServer.Test.Controllers
{
    public class LPCReportControllerTest
    {
        private readonly IServiceProvider serviceProvider;

        public LPCReportControllerTest()
        {
            var services = new ServiceCollection();
            services.AddDbContext<NYCLandmarkContext>(options => options.UseInMemoryDatabase());

            //Repositories
            services.AddScoped<ILPCReportRepository, LPCReportRepository>();
            services.AddScoped<ILandmarkRepository, LandmarkRepository>();

            //Services
            services.AddScoped<ILPCReportService, LPCReportService>();
            services.AddScoped<ILandmarkService, LandmarkService>();

            AutoMapperConfiguration.Configure();

            serviceProvider = services.BuildServiceProvider();
        }

        private void CreateTestData(NYCLandmarkContext dbContext)
        {
            var id = 1;
            GenFu.GenFu.Configure<LPCReport>()
                .Fill(l => l.Id, () => id++)
                .Fill(l => l.LPNumber, () => "LPCNumber" + (id++).ToString())
                .Fill(l => l.ObjectType, () => "ObjectType" + (id++).ToString());

            var lpcReports = GenFu.GenFu.ListOf<LPCReport>(20);

            dbContext.LPCReports.AddRange(lpcReports);

            var lmId = 1;
            GenFu.GenFu.Configure<Landmark>()
                .Fill(m => m.Id, () => lmId++)
                .Fill(m => m.LP_NUMBER, () => "LPCNumber" + (lmId++).ToString());

            var landmarks = GenFu.GenFu.ListOf<Landmark>(20);

            dbContext.Landmarks.AddRange(landmarks);
            dbContext.SaveChanges();
        }

        private LPCReportController PrepareController()
        {
            var dbContext = serviceProvider.GetRequiredService<NYCLandmarkContext>();
            dbContext.Database.EnsureDeleted();

            CreateTestData(dbContext);

            var lpcReportSvc = serviceProvider.GetRequiredService<ILPCReportService>();
            var landmarkSvc = serviceProvider.GetRequiredService<ILandmarkService>();

            return new LPCReportController(lpcReportSvc, landmarkSvc);
        }


        [Fact]
        public void DbContext_Should_Have_Records()
        {
            var controller = PrepareController();
            var dbContext = serviceProvider.GetRequiredService<NYCLandmarkContext>();

            Assert.Equal(20, dbContext.LPCReports.ToList().Count());
            Assert.Equal(20, dbContext.Landmarks.ToList().Count());
        }


        [Fact]
        public void Get_Should_Have_Record()
        {
            var controller = PrepareController();

            var id = 10;
            var actionResult = controller.Get(id);

            // Assert
            actionResult.Should().BeOfType<ObjectResult>();

            //// Assert
            //actionResult.Should().BeOfType<ObjectResult>()
            //    .Which.Should().BeOfType<LPCReportModel>()
            //    .Which.Id.Should().Be(id);
        }


        [Fact]
        public void Get_Should_Return_BadRequest()
        {
            var controller = PrepareController();

            var actionResult = controller.Get(0);

            // Assert
            actionResult.Should().BeOfType<BadRequestResult>();
        }






        //[Fact]
        //public void Get_Should_Return_Correct_Record()
        //{
        //    var controller = PrepareController();

        //    var model = new LPCReportRequestModel
        //    {
        //        ObjectType = "ObjectType5",
        //    };

        //    var actionResult = controller.Get(null, 5, 1);

        //    // Assert
        //    actionResult.Should().BeOfType<IEnumerable<LPCReportModel>>()
        //      //  .Which.Count().Equals(1)
        //      ;
        //}







        //[Fact]
        //public void Put_Should_Be_Able_To_Update_Record()
        //{
        //    var controller = PrepareController();

        //    var id = 11;
        //    var model = new LPCReportModel
        //    {

        //    };

        //    var actionResult = controller.Put(id, model);

        //    // Assert
        //    actionResult.Should().BeOfType<OkResult>();
        //}


        //[Fact]
        //public void Put_Should_Return_NoContent()
        //{
        //    var controller = PrepareController();

        //    var id = 110;
        //    var model = new LPCReportModel
        //    {

        //    };

        //    var actionResult = controller.Put(id, model);

        //    // Assert
        //    actionResult.Should().BeOfType<NoContentResult>();
        //}


        //[Fact]
        //public void Put_Should_Return_NotFound()
        //{
        //    var controller = PrepareController();

        //    var id = 110;
        //    var model = new LPCReportModel
        //    {

        //    };

        //    var actionResult = controller.Put(id, model);

        //    Assert
        //    actionResult.Should().BeOfType<NotFoundResult>();
        //}











        //[Fact]
        //public void Get_Should_Return_No_Record()
        //{
        //    var controller = PrepareController();

        //    var model = new LPCReportRequestModel
        //    {
        //        ObjectType = "ObjectType45",
        //    };

        //    var actionResult = controller.Get(model, 5, 1);

        //    // Assert
        //    actionResult.Should().BeOfType<IEnumerable<LPCReportModel>>()
        //        .Which.Count().Should().Equals(0);
        //}




        //[Fact]
        //public void GetLandmarks_Should_Return_Correct_Record()
        //{
        //    var controller = PrepareController();

        //    var model = new LandmarkRequestModel
        //    {
        //        LPCNumber = "LPCNumber5",
        //    };

        //    var actionResult = controller.GetLandmarks(model, 5, 1);

        //    // Assert
        //    actionResult.Should().BeOfType<IEnumerable<LPCReportModel>>()
        //        .Which.Count().Should().Equals(1);
        //}

        //[Fact]
        //public void GetLandmarks_Should_Return_No_Record()
        //{
        //    var controller = PrepareController();

        //    var model = new LandmarkRequestModel
        //    {
        //        LPCNumber = "LPCNumberd5",
        //    };

        //    var actionResult = controller.GetLandmarks(model, 5, 1);

        //    Assert
        //    actionResult.Should().BeOfType<IEnumerable<LPCReportModel>>()
        //        .Which.Count().Should().Equals(0);
        //}





    }
}
