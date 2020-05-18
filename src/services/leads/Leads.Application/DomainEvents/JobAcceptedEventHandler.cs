using System.Threading;
using System.Threading.Tasks;
using Leads.Application.Integration.Seedwork;
using Leads.Domain.Events;
using Leads.Domain.Services;
using Leads.Domain.Services.Seedwork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Leads.Application.DomainEvents
{
    public class JobAcceptedEventHandler : INotificationHandler<JobAcceptedEvent>
    {
        private readonly IJobQueryService _jobQueryService;
        private readonly IJobService _jobService;
        private readonly INotificationService _notificationService;
        private readonly ILogger<JobAcceptedEventHandler> _logger;

        public JobAcceptedEventHandler( ILogger<JobAcceptedEventHandler> logger,
            IJobQueryService jobQueryService,
            IJobService jobService,
            INotificationService notificationService
        )
        {
            _logger = logger;
            _jobQueryService = jobQueryService;
            _jobService = jobService;
            _notificationService = notificationService;
        }

        public async Task Handle(JobAcceptedEvent notification, CancellationToken cancellationToken )
        {
            await _notificationService.NotifyAcceptedLeads( notification.ReferenceId );
        }
    }
}