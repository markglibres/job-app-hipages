using Leads.Domain.Entities;
using Leads.Infrastructure.MySqlDatabase.Entities;
using Leads.Infrastructure.MySqlDatabase.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Leads.Infrastructure.MySqlDatabase
{
    public class JobsDbContext : DbContext
    {
        public JobsDbContext( DbContextOptions<JobsDbContext> contextOptions )
            : base( contextOptions ) { }

        public DbSet<Suburb> Suburbs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfiguration( new CategoriesConfiguration() );
            modelBuilder.ApplyConfiguration( new JobsConfiguration() );
            modelBuilder.ApplyConfiguration( new SuburbsConfiguration() );
            modelBuilder.Model.UseSnakeCase();
            base.OnModelCreating( modelBuilder );
        }
    }
}