using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace InterdimensionalThings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //To test this, right click on project -> Properties -> Debug -> application arguments
            if ((args.Length > 0) && (args[0].ToLowerInvariant() == "scrape"))
            {
                Services.DataScraperService.Scrape();
            }
            else
            {
                BuildWebHost(args).Run();

            }
        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
