using System.Threading.Tasks;
using Leads.Domain.Entities.Seedwork;
using Leads.Domain.Events;

namespace Leads.Application.Services.Seedwork
{
    public interface IEventSourceService<T>
        where T : IDbEntity
    {
        Task Add( IEventSource domainEvent );
    }
}