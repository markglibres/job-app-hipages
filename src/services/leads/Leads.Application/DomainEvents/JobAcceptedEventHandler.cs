﻿using System.Threading;
using System.Threading.Tasks;
using Leads.Application.Services.Seedwork;
using Leads.Domain.Entities;
using Leads.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Leads.Application.DomainEvents
{
    public class JobAcceptedEventHandler : INotificationHandler<JobAcceptedEvent>
    {
        private readonly IEventSourceService<Job> _eventSourceService;
        private readonly ILogger<JobAcceptedEventHandler> _logger;
        private readonly INotificationService _notificationService;

        public JobAcceptedEventHandler( ILogger<JobAcceptedEventHandler> logger,
            INotificationService notificationService,
            IEventSourceService<Job> eventSourceService
        )
        {
            _logger = logger;
            _notificationService = notificationService;
            _eventSourceService = eventSourceService;
        }

        public async Task Handle( JobAcceptedEvent notification, CancellationToken cancellationToken )
        {
            await _notificationService.NotifyAcceptedLeads( notification.ReferenceId );
            await _eventSourceService.Add( notification );
        }
    }
}