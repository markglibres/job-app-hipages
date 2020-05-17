using System;
using Leads.Domain.Entities;
using Leads.Domain.Repositories;
using Leads.Domain.Services;
using Leads.Infrastructure.MySqlDatabase;
using Leads.Infrastructure.MySqlDatabase.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Leads.Presentation.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<JobsDbContext>(options => options
                .UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IDbRepository<Category>, CategoryRepository>();
            services.AddTransient<IDbRepository<Suburb>, SuburbRepository>();
            services.AddTransient<IDbRepository<Job>, JobRepository>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ISuburbService, SuburbService>();
            services.AddTransient<IJobService, JobService>();

            services.AddControllers();
            services.AddHealthChecks();

            services.AddCors(o => o.AddPolicy("LocalPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("LocalPolicy");
            }
            else
                app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("health");
            });
        }
    }
}