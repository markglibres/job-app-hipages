using System.Threading;
using System.Threading.Tasks;
using Leads.Domain.Entities;
using Leads.Domain.Events;
using Leads.Domain.Services.Seedwork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Leads.Application.DomainEvents.JobDeclined
{
    public class SaveToStoreOnJobDeclinedEventHandler : INotificationHandler<JobDeclinedEvent>
    {
        private readonly IEventSourceService<Job> _eventSourceService;
        private readonly ILogger<SaveToStoreOnJobDeclinedEventHandler> _logger;

        public SaveToStoreOnJobDeclinedEventHandler( ILogger<SaveToStoreOnJobDeclinedEventHandler> logger,
            IEventSourceService<Job> eventSourceService
        )
        {
            _logger = logger;
            _eventSourceService = eventSourceService;
        }

        public async Task Handle(JobDeclinedEvent notification, CancellationToken cancellationToken )
        {
            await _eventSourceService.Add( notification );
        }
    }
}