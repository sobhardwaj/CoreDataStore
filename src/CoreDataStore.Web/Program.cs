using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace CoreDataStore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hosting.json", optional: true)
                .AddEnvironmentVariables("")
                .AddCommandLine(args)
                .Build();

            var url = config["ASPNETCORE_URLS"] ?? "http://*:5000";  //TOOD Set Default from Hosting
            var env = config["ASPNETCORE_ENVIRONMENT"] ?? "Development";

            Console.WriteLine("ASPNETCORE_URLS:{0}", url);
            Console.WriteLine("ASPNETCORE_ENVIRONMENT:{0}", env);

            var host = new WebHostBuilder()
                .UseConfiguration(config)
                .UseKestrel()
                .UseUrls(url)
                .UseEnvironment(env)
                .UseIISIntegration()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
