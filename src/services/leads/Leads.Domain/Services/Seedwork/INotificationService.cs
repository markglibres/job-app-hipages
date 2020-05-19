using System;
using System.Threading.Tasks;

namespace Leads.Domain.Services.Seedwork
{
    public interface INotificationService
    {
        Task NotifyAcceptedLeads( Guid referenceId );
    }
}