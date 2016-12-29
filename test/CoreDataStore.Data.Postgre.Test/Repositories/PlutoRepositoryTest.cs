using System.IO;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.Postgre.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CoreDataStore.Data.Postgre.Test.Repositories
{
    public class PlutoRepositoryTest
    {
       private readonly IPlutoRepository _plutoRepository;

       public PlutoRepositoryTest()
       {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var dbonnection = builder.GetConnectionString("PostgreSQL");

            var serviceProvider = new ServiceCollection()
                .AddDbContext<NYCLandmarkContext>(options => options.UseNpgsql(dbonnection))
                .AddScoped<IPlutoRepository, PlutoRepository>()
                .BuildServiceProvider();

             serviceProvider.GetRequiredService<NYCLandmarkContext>();
            _plutoRepository = serviceProvider.GetRequiredService<IPlutoRepository>();

        }


        //[Fact]
        [Fact(Skip = "ci test")]
        public void Pluto_Block_Lot_Exist()
        {
            var results = _plutoRepository.FindBy(x => x.Block == 1096 && x.Lot == 54);
            Assert.NotNull(results);
        }

        //[Fact]
        [Fact(Skip = "ci test")]
        public void Pluto_BBL_Exist()
        {
            var results = _plutoRepository.FindBy(x => x.BBL == 5080500013);
            Assert.NotNull(results);
        }

    }
}
