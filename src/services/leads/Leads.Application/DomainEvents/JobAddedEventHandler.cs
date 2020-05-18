using System.Threading;
using System.Threading.Tasks;
using Leads.Domain.Events;
using Leads.Domain.Services;
using Leads.Domain.Services.Seedwork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Leads.Application.DomainEvents
{
    public class JobAddedEventHandler : INotificationHandler<JobAddedEvent>
    {
        private readonly IJobQueryService _jobQueryService;
        private readonly IJobService _jobService;
        private readonly ILogger<JobAddedEventHandler> _logger;

        public JobAddedEventHandler( ILogger<JobAddedEventHandler> logger,
            IJobService jobService,
            IJobQueryService jobQueryService
        )
        {
            _logger = logger;
            _jobService = jobService;
            _jobQueryService = jobQueryService;
        }

        public async Task Handle( JobAddedEvent notification, CancellationToken cancellationToken )
        {
            var entity = await _jobService.GetByReferenceId( notification.ReferenceId );

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