using System.Threading;
using System.Threading.Tasks;
using Leads.Domain.Entities;
using Leads.Domain.Events;
using Leads.Domain.Services.Seedwork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Leads.Application.DomainEvents.JobUpdated
{
    public class SaveToStoreOnJobUpdatedEventHandler : INotificationHandler<JobUpdatedEvent>
    {
        private readonly IEventSourceService<Job> _eventSourceService;
        private readonly ILogger<SaveToQueryOnJobUpdatedEventHandler> _logger;

        public SaveToStoreOnJobUpdatedEventHandler( ILogger<SaveToQueryOnJobUpdatedEventHandler> logger,
            IEventSourceService<Job> eventSourceService
        )
        {
            _logger = logger;
            _eventSourceService = eventSourceService;
        }

        public async Task Handle( JobUpdatedEvent notification, CancellationToken cancellationToken )
        {
            await _eventSourceService.Add( notification );
        }
    }
}