using System;
using System.IO;
using System.Net.Http;
using CoreDataStore.Web.Test.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace CoreDataStore.Web.Test.Fixtures
{
    public class TestServerFixture : IDisposable
    {
        private readonly TestServer _testServer;

        public TestServerFixture()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Testing";

            var x = WebTestHelpers.GetWebApplicationPath();


            var builder = new WebHostBuilder()
                .UseEnvironment(environment)
                .UseContentRoot(WebTestHelpers.GetWebApplicationPath())
                .UseConfiguration(Configuration)
                .UseStartup<TestStartup>();

            _testServer = new TestServer(builder);

            Client = _testServer.CreateClient();
            Client.BaseAddress = new Uri("http://localhost:5000");
        }

        public HttpClient Client { get; }

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(WebTestHelpers.GetWebApplicationPath())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Testing"}.json", optional: true)
            .Build();

        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && Client != null)
            {
                Client.Dispose();
                _testServer.Dispose();
            }
        }
    }
}
