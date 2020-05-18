using System;
using BizzPo.Core.Domain;
using MediatR;

namespace Leads.Domain.Events
{
    public class JobStatusUpdatedEvent : IEvent, INotification
    {
        public JobStatusUpdatedEvent( Guid referenceId,
            string jobStatus
        )
        {
            Id = Guid.NewGuid().ToString();
            ReferenceId = referenceId;
            JobStatus = jobStatus;
        }

        public Guid ReferenceId { get; private set; }
        public string JobStatus { get; private set; }
        public string Id { get; private set; }
    }
}