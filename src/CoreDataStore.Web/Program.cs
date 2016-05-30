using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CoreDataStore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //http://stackoverflow.com/questions/34212765/how-do-i-get-the-kestrel-web-server-to-listen-to-non-localhost-requests

            var host = new WebHostBuilder()
                .UseUrls("http://0.0.0.0:5000/")  //Programatically Set the Port (Use hosting.json)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
