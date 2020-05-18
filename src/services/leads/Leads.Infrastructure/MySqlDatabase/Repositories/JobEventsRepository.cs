using Leads.Application.Services.JobEventsSource;

namespace Leads.Infrastructure.MySqlDatabase.Repositories
{
    public class JobEventsRepository : MySqlDbRepository<JobEvent>
    {
        public JobEventsRepository( JobsEventSourcingDbContext dbContext ) : base( dbContext ) { }
    }
}