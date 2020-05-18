using Leads.Application.Services.JobEventsSource;
using Leads.Infrastructure.MySqlDatabase.Entities;
using Leads.Infrastructure.MySqlDatabase.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Leads.Infrastructure.MySqlDatabase
{
    public class JobsEventSourcingDbContext : DbContext
    {
        public JobsEventSourcingDbContext( DbContextOptions<JobsEventSourcingDbContext> contextOptions )
            : base( contextOptions ) { }

        public DbSet<JobEvent> JobEvents { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfiguration( new JobEventsConfiguration() );
            modelBuilder.Model.UseSnakeCase();
            base.OnModelCreating( modelBuilder );
        }
    }
}