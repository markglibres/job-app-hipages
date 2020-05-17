using Leads.Domain.Entities;

namespace Leads.Infrastructure.MySqlDatabase.Repositories
{
    public class JobInfoRepository : MySqlDbRepository<JobInfo>
    {
        public JobInfoRepository(JobsDbContext dbContext) : base(dbContext)
        {
        }
    }
}