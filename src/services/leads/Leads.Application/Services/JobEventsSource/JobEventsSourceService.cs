using System;
using System.Linq;
using System.Threading.Tasks;
using Leads.Application.Services.Seedwork;
using Leads.Domain.Entities;
using Leads.Domain.Events;
using Leads.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Leads.Application.Services.JobEventsSource
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