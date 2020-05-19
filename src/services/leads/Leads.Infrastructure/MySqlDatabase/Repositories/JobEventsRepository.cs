using Leads.Domain.Entities;

namespace Leads.Infrastructure.MySqlDatabase.Repositories
{
    public class JobEventsRepository : MySqlDbRepository<JobEvent>
    {
        public JobEventsRepository( JobsEventSourcingDbContext dbContext ) : base( dbContext ) { }
    }
}