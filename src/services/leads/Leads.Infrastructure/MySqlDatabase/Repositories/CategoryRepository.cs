using Leads.Domain.Entities;

namespace Leads.Infrastructure.MySqlDatabase.Repositories
{
    public class CategoryRepository : MySqlDbRepository<Category>
    {
        public CategoryRepository( JobsDbContext dbContext ) : base( dbContext ) { }
    }
}