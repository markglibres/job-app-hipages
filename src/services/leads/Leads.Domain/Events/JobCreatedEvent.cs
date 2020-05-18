using System;
using Leads.Domain.Constants;
using Leads.Domain.ValueObjects;
using MediatR;
using Newtonsoft.Json;

namespace Leads.Domain.Events
{
    public class JobCreatedEvent : IEventSource, INotification
    {
        [JsonConstructor]
        private JobCreatedEvent() { }

        public JobCreatedEvent( Guid referenceId,
            decimal price,
            string description,
            Contact contact,
            int suburbId,
            int categoryId,
            JobStatus jobStatus
        )
        {
            ReferenceId = referenceId;
            Id = Guid.NewGuid().ToString();
            Price = price;
            Description = description;
            Contact = contact;
            SuburbId = suburbId;
            CategoryId = categoryId;
            JobStatus = jobStatus;
            ReferenceId = referenceId;
        }

        public int CategoryId { get; private set; }
        public JobStatus JobStatus { get; private set; }

        public int SuburbId { get; private set; }

        public string Description { get; private set; }
        public Contact Contact { get; private set; }
        public decimal Price { get; private set; }

        public Guid ReferenceId { get; private set; }
        public string Id { get; private set; }
    }
}