using System;
using BizzPo.Core.Domain;
using MediatR;
using Newtonsoft.Json;

namespace Leads.Domain.Events
{
    public class JobAcceptedEvent : IEventSource, INotification
    {
        [JsonConstructor]
        private JobAcceptedEvent() { }
        public JobAcceptedEvent( Guid referenceId)
        {
            Id = Guid.NewGuid().ToString();
            ReferenceId = referenceId;
        }

        public Guid ReferenceId { get; private set; }
        public string Id { get; private set; }
    }
}