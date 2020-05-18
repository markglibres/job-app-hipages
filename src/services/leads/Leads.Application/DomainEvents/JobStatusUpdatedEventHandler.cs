using System.Threading;
using System.Threading.Tasks;
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
        private readonly ILogger<JobAddedEventHandler> _logger;

        public JobUpdatedEventHandler( ILogger<JobAddedEventHandler> logger,
            IJobQueryService jobQueryService,
            IJobService jobService
        )
        {
            _logger = logger;
            _jobQueryService = jobQueryService;
            _jobService = jobService;
        }

        public async Task Handle( JobUpdatedEvent notification, CancellationToken cancellationToken )
        {
            var entity = await _jobService.GetByReferenceId(notification.ReferenceId);

            await _jobQueryService.UpdateJobAsync(
                entity.ReferenceId,
                entity.Price,
                entity.Status.ToString()
            );
        }
    }
}