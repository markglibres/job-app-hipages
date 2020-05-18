using System.Threading;
using System.Threading.Tasks;
using Leads.Application.Services.Seedwork;
using Leads.Domain.Entities;
using Leads.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Leads.Application.DomainEvents
{
    public class JobDeclinedEventHandler : INotificationHandler<JobDeclinedEvent>
    {
        private readonly IEventSourceService<Job> _eventSourceService;
        private readonly ILogger<JobDeclinedEventHandler> _logger;

        public JobDeclinedEventHandler( ILogger<JobDeclinedEventHandler> logger,
            INotificationService notificationService,
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