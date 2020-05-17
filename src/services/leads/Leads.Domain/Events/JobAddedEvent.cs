﻿using System;
using BizzPo.Core.Domain;
using MediatR;

namespace Leads.Domain.Events
{
    public class JobAddedEvent : IEvent, INotification
    {
        public Guid ReferenceId { get; private set; }
        public string Id { get; private set; }
        public JobAddedEvent(Guid referenceId)
        {
            ReferenceId = referenceId;
            Id = Guid.NewGuid().ToString();
        }

    }
}