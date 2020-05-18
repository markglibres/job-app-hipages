using BizzPo.Core.Domain;
using Leads.Application.GetInvitedLeads;
using Leads.Application.Integration.Seedwork;
using Leads.Domain.Entities;
using Leads.Domain.Repositories;
using Leads.Domain.Services;
using Leads.Domain.Services.Discounts;
using Leads.Domain.Services.Seedwork;
using Leads.Infrastructure.DomainEvents;
using Leads.Infrastructure.MySqlDatabase;
using Leads.Infrastructure.MySqlDatabase.Repositories;
using Leads.Infrastructure.Notifications;
using MediatR;
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
        public Startup( IConfiguration configuration ) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddDbContext<JobsDbContext>(
                options => options
                    .UseMySql( Configuration.GetConnectionString( "DefaultConnection" ) )
            );

            services.AddMediatR( typeof( GetInvitedLeadsQuery ).Assembly );

            services.AddTransient<IDbRepository<Category>, CategoryRepository>();
            services.AddTransient<IDbRepository<Suburb>, SuburbRepository>();
            services.AddTransient<IDbRepository<Job>, JobRepository>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ISuburbService, SuburbService>();
            services.AddTransient<IJobService, JobService>();
            services.AddTransient<IJobQueryService, JobQueryService>();
            services.AddTransient<IDbRepository<JobInfo>, JobInfoRepository>();
            services.AddTransient<IDiscountService, Above500Discount>();

            services.AddTransient<IDomainEventsService, MediatrEventsService>();

            services.AddTransient<INotificationService, EmailNotificationService>();
            services.Configure<NotificationConfig>(Configuration.GetSection("Notifications"));

            services.AddControllers();
            services.AddHealthChecks();

            services.AddCors(
                o => o.AddPolicy(
                    "LocalPolicy",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    }
                )
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
                app.UseCors( "LocalPolicy" );
            }
            else
            {
                app.UseHttpsRedirection();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapHealthChecks( "health" );
                }
            );
        }
    }
}