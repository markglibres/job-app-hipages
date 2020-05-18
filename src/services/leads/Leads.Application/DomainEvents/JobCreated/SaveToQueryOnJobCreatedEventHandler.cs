using System.Threading;
using System.Threading.Tasks;
using Leads.Application.Services.Seedwork;
using Leads.Domain.Events;
using Leads.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Leads.Application.DomainEvents.JobCreated
{
    public class SaveToQueryOnJobCreatedEventHandler : INotificationHandler<JobCreatedEvent>
    {
        private readonly IJobQueryService _jobQueryService;
        private readonly IJobService _jobService;
        private readonly ILogger<SaveToQueryOnJobCreatedEventHandler> _logger;

        public SaveToQueryOnJobCreatedEventHandler( ILogger<SaveToQueryOnJobCreatedEventHandler> logger,
            IJobService jobService,
            IJobQueryService jobQueryService
        )
        {
            _logger = logger;
            _jobService = jobService;
            _jobQueryService = jobQueryService;
        }

        public async Task Handle( JobCreatedEvent notification, CancellationToken cancellationToken )
        {
            var entity = await _jobService.GetByReferenceIdAsync( notification.ReferenceId );

            await _jobQueryService.InsertJobAsync(
                entity.Id,
                entity.ReferenceId,
                entity.Price,
                entity.Description,
                entity.Contact.Name,
                entity.Contact.Phone,
                entity.Contact.Email,
                entity.Suburb.Name,
                entity.Suburb.PostCode,
                entity.Category.Name,
                entity.Status.ToString(),
                entity.CreatedAt
            );
        }
    }
}