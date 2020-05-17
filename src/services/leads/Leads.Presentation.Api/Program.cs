using System;
using Leads.Infrastructure.MySqlDatabase;
using Leads.Presentation.Api.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Leads.Presentation.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger();

                var host = CreateHostBuilder(args).Build();

                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var environment = services.GetService<IHostEnvironment>();

                    Log.Logger.Information($"Environment is: {environment.EnvironmentName}");
                    if (!environment.IsDevelopment()) return;

                    Log.Information("Migrating database...");
                    var context = services.GetRequiredService<JobsDbContext>();
                    context.Database.Migrate();

                    SeedCategory.EnsureSeedData(services);
                    SeedSuburbs.EnsureSeedData(services);
                    SeedJobs.EnsureSeedData(services);
                }
            
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"Application start-up failed: {ex.Message}");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}