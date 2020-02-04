using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MonteOlimpo.Base.Extensions.Configuration;
using System.IO;

namespace MultiTenantCore
{
    public class Program
	{
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
              .UseKestrel()
                  .UseContentRoot(Directory.GetCurrentDirectory())
                      .UseUrls("http://localhost:60000", "http://localhost:60001", "http://localhost:60002")
                           .ConfigureAppConfiguration(ConfigurationExtensions.AddMonteOlimpoConfiguration)
                                .UseStartup<Startup>();
    }
}