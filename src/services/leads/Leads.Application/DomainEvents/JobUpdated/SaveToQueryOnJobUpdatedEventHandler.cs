using System.Threading;
using System.Threading.Tasks;
using Leads.Domain.Events;
using Leads.Domain.Services;
using Leads.Domain.Services.Seedwork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Leads.Application.DomainEvents.JobUpdated
{
    public class SaveToQueryOnJobUpdatedEventHandler : INotificationHandler<JobUpdatedEvent>
    {
        private readonly IJobQueryService _jobQueryService;
        private readonly IJobService _jobService;
        private readonly ILogger<SaveToQueryOnJobUpdatedEventHandler> _logger;

        public SaveToQueryOnJobUpdatedEventHandler( ILogger<SaveToQueryOnJobUpdatedEventHandler> logger,
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
            var entity = await _jobService.GetByReferenceIdAsync( notification.ReferenceId );

            await _jobQueryService.UpdateJobAsync(
                entity.ReferenceId,
                entity.Price,
                entity.Status.ToString()
            );
        }
    }
}