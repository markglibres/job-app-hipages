using System.Threading;
using System.Threading.Tasks;
using Leads.Application.Services.Seedwork;
using Leads.Domain.Entities;
using Leads.Domain.Events;
using Leads.Domain.Services;
using Leads.Domain.Services.Seedwork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Leads.Application.DomainEvents
{
    public class JobUpdatedEventHandler : INotificationHandler<JobUpdatedEvent>
    {
        private readonly IJobQueryService _jobQueryService;
        private readonly IJobService _jobService;
        private readonly IEventSourceService<Job> _eventSourceService;
        private readonly ILogger<JobUpdatedEventHandler> _logger;

        public JobUpdatedEventHandler( ILogger<JobUpdatedEventHandler> logger,
            IJobQueryService jobQueryService,
            IJobService jobService,
            IEventSourceService<Job> eventSourceService
        )
        {
            _logger = logger;
            _jobQueryService = jobQueryService;
            _jobService = jobService;
            _eventSourceService = eventSourceService;
        }

        public async Task Handle(JobUpdatedEvent notification, CancellationToken cancellationToken )
        {
            var entity = await _jobService.GetByReferenceIdAsync(notification.ReferenceId);

            await _jobQueryService.UpdateJobAsync(
                entity.ReferenceId,
                entity.Price,
                entity.Status.ToString()
            );

            await _eventSourceService.Add( notification );
        }
    }
}