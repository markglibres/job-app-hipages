using System;
using BizzPo.Core.Domain;
using MediatR;

namespace Leads.Domain.Events
{
    public class JobUpdatedEvent : IEvent, INotification
    {
        public JobUpdatedEvent( Guid referenceId)
        {
            Id = Guid.NewGuid().ToString();
            ReferenceId = referenceId;
        }

        public Guid ReferenceId { get; private set; }
        public string Id { get; private set; }
    }
}