using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Logging;

namespace Dapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                // Following configuration is to register all the property files
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.Sources.Insert(0, new JsonConfigurationSource { Path = "appsettings.json", Optional = false, ReloadOnChange = true });
                })
                .UseStartup<Startup>();
    }
}
