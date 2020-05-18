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
    public class JobCreatedEventHandler : INotificationHandler<JobCreatedEvent>
    {
        private readonly IJobQueryService _jobQueryService;
        private readonly IEventSourceService<Job> _eventSourceService;
        private readonly IJobService _jobService;
        private readonly ILogger<JobCreatedEventHandler> _logger;

        public JobCreatedEventHandler( ILogger<JobCreatedEventHandler> logger,
            IJobService jobService,
            IJobQueryService jobQueryService,
            IEventSourceService<Job> eventSourceService
        )
        {
            _logger = logger;
            _jobService = jobService;
            _jobQueryService = jobQueryService;
            _eventSourceService = eventSourceService;
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

            await _eventSourceService.Add(notification);
        }
    }
}