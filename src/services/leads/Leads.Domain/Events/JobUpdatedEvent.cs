using System;
using BizzPo.Core.Domain;
using Leads.Domain.Constants;
using MediatR;
using Newtonsoft.Json;

namespace Leads.Domain.Events
{
    public class JobUpdatedEvent : IEventSource, INotification
    {
        [JsonConstructor]
        private JobUpdatedEvent() { }
        public JobUpdatedEvent( Guid referenceId, decimal price, JobStatus jobStatus)
        {
            Id = Guid.NewGuid().ToString();
            ReferenceId = referenceId;
            Price = price;
            JobStatus = jobStatus;
        }

        public Guid ReferenceId { get; private set; }
        public decimal Price { get; private set; }
        public JobStatus JobStatus { get; private set; }
        public string Id { get; private set; }
    }
}