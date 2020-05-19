using System;
using Leads.Domain.Entities.Seedwork;
using Newtonsoft.Json;

namespace Leads.Domain.Entities
{
    public class JobEvent : IDbEntity
    {
        [JsonConstructor]
        private JobEvent() { }
        public JobEvent( string eventId,
            Guid referenceId,
            string eventType,
            string eventName,
            object eventData
        )
        {
            EventId = Guid.TryParse( eventId, out var id ) ? id : Guid.NewGuid();
            ReferenceId = referenceId;
            EventType = eventType;
            EventName = eventName;
            EventData = eventData;
            DateCreated = DateTime.Now;
        }

        public Guid EventId { get; private set; }
        public Guid ReferenceId { get; private set; }
        public string EventType { get; private set; }
        public string EventName { get; private set; }
        public object EventData { get; private set; }
        public DateTime DateCreated { get; private set; }
        public int Id { get; private set; }
    }
}