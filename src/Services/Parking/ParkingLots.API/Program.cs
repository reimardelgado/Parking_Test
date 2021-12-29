using System;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParkingLots.Infrastructure;

namespace ParkingLots.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var host = CreateHostBuilder(args).Build();

                using var scope = host.Services.CreateScope();
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();

                // Ensure the database is created
                Console.WriteLine("Applying migrations");
                await context.Database.MigrateAsync();
                Console.WriteLine("Applying migrations done");
                
                await host.RunAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}: Application failed to start");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory());
    }
}
