using Leads.Application.Services.JobQuery;
using Leads.Domain.Entities;
using Leads.Infrastructure.MySqlDatabase.Entities;
using Leads.Infrastructure.MySqlDatabase.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Leads.Infrastructure.MySqlDatabase
{
    public class JobsQueryDbContext : DbContext
    {
        public JobsQueryDbContext( DbContextOptions<JobsQueryDbContext> contextOptions )
            : base( contextOptions ) { }

        public DbSet<JobInfo> JobsInfo { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfiguration(new JobsInfoConfiguration());
            modelBuilder.Model.UseSnakeCase();
            base.OnModelCreating( modelBuilder );
        }
    }
}