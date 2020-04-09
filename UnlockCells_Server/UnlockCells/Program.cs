using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UnlockCells;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = CreateHostBuilder(args).Build();
        using (var scope = host.Services.CreateScope())
        {
            // Retrieve your DbContext isntance here
            var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
           // DbInitializer.Seed(dbContext);
        }

        host.Run();

    }
    public static IHostBuilder CreateHostBuilder(string[] args)
    => Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(
            webBuilder => webBuilder.UseStartup<Startup>());
}
