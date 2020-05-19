using System.Collections.Generic;

namespace Leads.Infrastructure.Services.Notifications
{
    public class NotificationConfig
    {
        public NotificationConfigItem AcceptedJob { get; set; }
    }

    public class NotificationConfigItem
    {
        public IEnumerable<string> Recipients { get; set; }
        public string Subject { get; set; }
    }
}