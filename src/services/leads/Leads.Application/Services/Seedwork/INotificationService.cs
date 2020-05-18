using System;
using System.Threading.Tasks;

namespace Leads.Application.Services.Seedwork
{
    public interface INotificationService
    {
        Task NotifyAcceptedLeads( Guid referenceId );
    }
}