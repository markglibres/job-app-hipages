using System.Threading;
using System.Threading.Tasks;
using Leads.Application.Services.Seedwork;
using Leads.Domain.Entities;
using Leads.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Leads.Application.DomainEvents.JobAccepted
{
    public class SaveToStoreOnJobAcceptedEventHandler : INotificationHandler<JobAcceptedEvent>
    {
        private readonly IEventSourceService<Job> _eventSourceService;
        private readonly ILogger<SaveToStoreOnJobAcceptedEventHandler> _logger;

        public SaveToStoreOnJobAcceptedEventHandler( ILogger<SaveToStoreOnJobAcceptedEventHandler> logger,
            IEventSourceService<Job> eventSourceService
        )
        {
            _logger = logger;
            _eventSourceService = eventSourceService;
        }

        public async Task Handle( JobAcceptedEvent notification, CancellationToken cancellationToken )
        {
            await _eventSourceService.Add( notification );
        }
    }
}