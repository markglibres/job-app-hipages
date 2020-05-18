using Leads.Application.Services.JobQuery;
using Leads.Domain.Entities;

namespace Leads.Infrastructure.MySqlDatabase.Repositories
{
    public class JobInfoRepository : MySqlDbRepository<JobInfo>
    {
        public JobInfoRepository(JobsQueryDbContext dbContext ) : base( dbContext ) { }
    }
}