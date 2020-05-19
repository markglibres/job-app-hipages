using System.Threading.Tasks;
using Leads.Domain.Entities;
using Leads.Domain.Events;
using Leads.Domain.Repositories;
using Leads.Domain.Services.Seedwork;
using Microsoft.Extensions.Logging;

namespace Leads.Infrastructure.Services
{
    public class JobEventsSourceService : IEventSourceService<Job>
    {
        private readonly ILogger<JobEventsSourceService> _logger;
        private readonly IDbRepository<JobEvent> _repository;

        public JobEventsSourceService( ILogger<JobEventsSourceService> logger,
            IDbRepository<JobEvent> repository
        )
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task Add( IEventSource domainEventSource )
        {
            var type = domainEventSource.GetType();

            var entity = new JobEvent(
                domainEventSource.Id,
                domainEventSource.ReferenceId,
                type.FullName,
                type.Name,
                domainEventSource
            );

            await _repository.InsertAsync( entity );
        }
    }
}