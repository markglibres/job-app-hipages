using System;
using System.Threading.Tasks;

namespace Leads.Application.Integration.Seedwork
{
    public interface INotificationService
    {
        Task NotifyAcceptedLeads( Guid referenceId );
    }
}