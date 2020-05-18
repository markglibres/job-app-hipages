using Leads.Domain.Entities;

namespace Leads.Infrastructure.MySqlDatabase.Repositories
{
    public class SuburbRepository : MySqlDbRepository<Suburb>
    {
        public SuburbRepository( JobsDbContext dbContext ) : base( dbContext ) { }
    }
}