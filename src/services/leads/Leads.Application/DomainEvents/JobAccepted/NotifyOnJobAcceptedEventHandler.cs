using System.Threading;
using System.Threading.Tasks;
using Leads.Domain.Events;
using Leads.Domain.Services.Seedwork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Leads.Application.DomainEvents.JobAccepted
{
    public class NotifyOnJobAcceptedEventHandler : INotificationHandler<JobAcceptedEvent>
    {
        private readonly ILogger<SaveToStoreOnJobAcceptedEventHandler> _logger;
        private readonly INotificationService _notificationService;

        public NotifyOnJobAcceptedEventHandler( ILogger<SaveToStoreOnJobAcceptedEventHandler> logger,
            INotificationService notificationService
        )
        {
            _logger = logger;
            _notificationService = notificationService;
        }

        public async Task Handle( JobAcceptedEvent notification, CancellationToken cancellationToken )
        {
            await _notificationService.NotifyAcceptedLeads( notification.ReferenceId );
        }
    }
}