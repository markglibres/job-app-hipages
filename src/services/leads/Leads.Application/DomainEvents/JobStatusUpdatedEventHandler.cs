using System.Threading;
using System.Threading.Tasks;
using Leads.Domain.Events;
using Leads.Domain.Services.Seedwork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Leads.Application.DomainEvents
{
    public class JobStatusUpdatedEventHandler : INotificationHandler<JobStatusUpdatedEvent>
    {
        private readonly IJobQueryService _jobQueryService;
        private readonly ILogger<JobAddedEventHandler> _logger;

        public JobStatusUpdatedEventHandler(
            ILogger<JobAddedEventHandler> logger,
            IJobQueryService jobQueryService)
        {
            _logger = logger;
            _jobQueryService = jobQueryService;
        }

        public async Task Handle(JobStatusUpdatedEvent notification, CancellationToken cancellationToken)
        {
            await _jobQueryService.UpdateStatus(
                notification.ReferenceId,
                notification.JobStatus);
        }
    }
}