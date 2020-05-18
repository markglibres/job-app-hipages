using System.Threading;
using System.Threading.Tasks;
using Leads.Application.Services.Seedwork;
using Leads.Domain.Entities;
using Leads.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Leads.Application.DomainEvents.JobCreated
{
    public class SaveToStoreOnJobCreatedEventHandler : INotificationHandler<JobCreatedEvent>
    {
        private readonly IEventSourceService<Job> _eventSourceService;
        private readonly ILogger<SaveToQueryOnJobCreatedEventHandler> _logger;

        public SaveToStoreOnJobCreatedEventHandler( ILogger<SaveToQueryOnJobCreatedEventHandler> logger,
            IEventSourceService<Job> eventSourceService
        )
        {
            _logger = logger;
            _eventSourceService = eventSourceService;
        }

        public async Task Handle( JobCreatedEvent notification, CancellationToken cancellationToken )
        {
            await _eventSourceService.Add( notification );
        }
    }
}