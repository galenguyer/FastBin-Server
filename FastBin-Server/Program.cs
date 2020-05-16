using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FastBin_Server.Database;

namespace FastBin_Server
{
    public class Program
    {
        public static Configuration Configuration = new Configuration();
        public static LiteDBClient dbClient;

        public static void Main(string[] args)
        {
            Configuration = Configuration.Load();
            dbClient = new LiteDBClient(Configuration.DatabasePath);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseUrls("http://0.0.0.0:28377");
;
                });
    }
}
