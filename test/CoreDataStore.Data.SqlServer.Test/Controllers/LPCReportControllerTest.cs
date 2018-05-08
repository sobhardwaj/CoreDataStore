using System;
using System.Collections.Generic;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.SqlServer.Repositories;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Service.Interfaces;
using CoreDataStore.Service.Mappings;
using CoreDataStore.Service.Services;
using CoreDataStore.Web.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using System.Linq;
using CoreDataStore.Domain.Enum;
using FluentAssertions;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using Navigator.Common.Helpers;


namespace CoreDataStore.Data.SqlServer.Test.Controllers
{
    public class LPCReportControllerTest
    {
        private readonly IServiceProvider _serviceProvider;

        private IEnumerable<LPCReport> _lpcReports = new List<LPCReport>();
        private IEnumerable<Landmark> _landmarks = new List<Landmark>();
        
        public LPCReportControllerTest()
        {
            var services = new ServiceCollection();
            services.AddDbContext<NYCLandmarkContext>(options => options.UseInMemoryDatabase());

            //Repositories
            services.AddScoped<ILpcReportRepository, LPCReportRepository>();
            services.AddScoped<ILandmarkRepository, LandmarkRepository>();

            //Services
            services.AddScoped<ILPCReportService, LPCReportService>();
            services.AddScoped<ILandmarkService, LandmarkService>();

            AutoMapperConfiguration.Configure();
            _serviceProvider = services.BuildServiceProvider();
        }


        private void CreateTestData(NYCLandmarkContext dbContext)
        {
            var boroughs = EnumHelper.EnumToList<Borough>().Select(e => e.GetDescription());
            var boroughCodes = EnumHelper.EnumToList<Borough>().Select(e => e.GetAttribute<BoroughId>().Value);
            var objectTypes = EnumHelper.EnumToList<ObjectType>().Select(e => e.GetDescription());

            var i = 0;
            GenFu.GenFu.Configure<LPCReport>()
                .Fill(l => l.Id, () => ++i)
                .Fill(l => l.LPNumber, () => string.Format("LP-{0,5:D5}", i))
                .Fill(l => l.LPCId, () => string.Format("{0,5:D5}", i))
                .Fill(l => l.Borough, () => BaseValueGenerator.GetRandomValue(boroughs))
                .Fill(l => l.ObjectType, () => BaseValueGenerator.GetRandomValue(objectTypes))
                .Fill(l => l.Landmarks);
            _lpcReports = A.ListOf<LPCReport>(20);
            dbContext.LPCReports.AddRange(_lpcReports);
            dbContext.SaveChanges();
        }

        private LPCReportController PrepareController()
        {
            var dbContext = _serviceProvider.GetRequiredService<NYCLandmarkContext>();
            dbContext.Database.EnsureDeleted();

            CreateTestData(dbContext);

            var lpcReportSvc = _serviceProvider.GetRequiredService<ILPCReportService>();
            var landmarkSvc = _serviceProvider.GetRequiredService<ILandmarkService>();

            var controller = new LPCReportController(lpcReportSvc, landmarkSvc);

            return controller;
        }


        //[Fact, Trait("Category", "InMemoryDatabase")]
        //public void DbContext_Should_Have_Records()
        //{
        //    var controller = PrepareController();
        //    var dbContext = _serviceProvider.GetRequiredService<NYCLandmarkContext>();

        //    Assert.Equal(20, dbContext.LPCReports.ToList().Count());
        //}


        //[Fact, Trait("Category", "InMemoryDatabase")]
        //public void Get_Should_Have_Record()
        //{
        //    var controller = PrepareController();

        //    var id = 10;
        //    var actionResult = controller.Get(id);

        //    // Assert
        //    actionResult.Should().BeOfType<ObjectResult>();
        //}


        //[Fact, Trait("Category", "InMemoryDatabase")]
        //public void Get_Should_Return_BadRequest()
        //{
        //    var controller = PrepareController();

        //    var actionResult = controller.Get(0);

        //    // Assert
        //    actionResult.Should().BeOfType<BadRequestResult>();
        //}


        //[Fact, Trait("Category", "InMemoryDatabase")]
        //public void Paging_Should_Return_Correct_Record_Count()
        //{
        //    var controller = PrepareController();

        //    var model = new LPCReportRequestModel
        //    {
        //        ObjectType = "Individual Landmark",
        //    };

        //    //Response Header Null Exception
        //    var actionResult = controller.Get(model, 5, 1);

        //    // Assert
        //    actionResult.Should().BeOfType<IEnumerable<ObjectResult>>()
        //                       .Which.Count().Should().Be(5);

        //}


        //[Fact, Trait("Category", "InMemoryDatabase")]
        //public void Paging_Should_Return_No_Record()
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


        //[Fact, Trait("Category", "InMemoryDatabase")]
        //public void Put_Exception_Return_NoContent()
        //{
        //    var controller = PrepareController();

        //    var id = 110;

        //    var dbContext = _serviceProvider.GetRequiredService<NYCLandmarkContext>();
        //    var model1 = dbContext.LPCReports.Where(x => x.Id == 1);

        //    var model = new LPCReportModel { };

        //    var actionResult = controller.Put(id, model);

        //    // Assert
        //    actionResult.Should().BeOfType<NoContentResult>();
        //}


        //[Fact, Trait("Category", "InMemoryDatabase")]
        //public void Put_Sucess_Update_Record()
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

    }
}
