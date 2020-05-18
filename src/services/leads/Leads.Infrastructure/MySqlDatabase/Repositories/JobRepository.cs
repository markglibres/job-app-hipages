using Leads.Domain.Entities;

namespace Leads.Infrastructure.MySqlDatabase.Repositories
{
    public class JobRepository : MySqlDbRepository<Job>
    {
        public JobRepository( JobsDbContext dbContext ) : base( dbContext ) { }
    }
}