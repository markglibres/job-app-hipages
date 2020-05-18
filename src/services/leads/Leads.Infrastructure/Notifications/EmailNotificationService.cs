using System;
using System.Threading.Tasks;
using Leads.Application.Integration.Seedwork;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Leads.Infrastructure.Notifications
{
    public class EmailNotificationService : INotificationService
    {
        private readonly ILogger<EmailNotificationService> _logger;
        private readonly NotificationConfig _options;

        public EmailNotificationService( ILogger<EmailNotificationService> logger,
            IOptions<NotificationConfig> options
        )
        {
            _logger = logger;
            _options = options.Value;
        }

        public Task NotifyAcceptedLeads( Guid referenceId )
        {
            var recipients = _options.AcceptedJob.Recipients;
            var subject = _options.AcceptedJob.Subject;

            _logger.LogInformation( $"Sending notifications to {string.Join( ", ", recipients )}" );
            _logger.LogInformation( $"With subject of: {subject}" );

            return Task.CompletedTask;
        }
    }
}