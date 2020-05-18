using System;
using BizzPo.Core.Domain;

namespace Leads.Domain.Events
{
    public interface IEventSource : IEvent
    {
        Guid ReferenceId { get; }
    }
}