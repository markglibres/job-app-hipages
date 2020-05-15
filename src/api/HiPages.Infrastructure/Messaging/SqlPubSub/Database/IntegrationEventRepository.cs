using BizzPo.Core.Infrastructure.Repository.EntityFramework;

namespace HiPages.Infrastructure.Messaging.SqlPubSub.Database
{
    public class IntegrationEventRepository : SqlRepository<PubSubEvent>
    {
        public IntegrationEventRepository(IntegrationEventDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}