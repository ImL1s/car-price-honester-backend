﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CarPriceHonester.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                   .UseKestrel()
                   .UseUrls("http://*:80")
                    .ConfigureAppConfiguration((WebHostBuilder, ConfigurationBinder) =>
                    {
                        ConfigurationBinder.AddJsonFile("appsettings.json", optional: true);
                    });
    }
}
