using System;
using BizzPo.Core.Domain;
using MediatR;

namespace Leads.Domain.Events
{
    public class JobAcceptedEvent : IEvent, INotification
    {
        public JobAcceptedEvent( Guid referenceId)
        {
            Id = Guid.NewGuid().ToString();
            ReferenceId = referenceId;
        }

        public Guid ReferenceId { get; private set; }
        public string Id { get; private set; }
    }
}