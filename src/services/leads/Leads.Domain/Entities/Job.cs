using System;
using Ardalis.GuardClauses;
using BizzPo.Core.Domain;
using Leads.Domain.Constants;
using Leads.Domain.Entities.Seedwork;
using Leads.Domain.Extensions;
using Leads.Domain.ValueObjects;
using Newtonsoft.Json;

namespace Leads.Domain.Entities
{
    public class Job : IDbEntity
    {
        public int Id { get; private set; }
        public JobStatus Status { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }
        public int SuburbId { get; private set; }
        public Suburb Suburb { get; private set; }
        public Contact Contact { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public Guid ReferenceId { get; private set; }

        [JsonConstructor]
        private Job()
        {
            
        }

        public Job(
            decimal price, 
            string description, 
            Contact contact, 
            int suburbId, 
            int categoryId,
            Guid referenceId)
        {

            Guard.Against.ZeroOrNegative(price, nameof(Price));
            Guard.Against.Empty(description, nameof(Description));
            Guard.Against.NullObject(contact, nameof(Contact));
            Guard.Against.ZeroOrNegative(suburbId, nameof(SuburbId));
            Guard.Against.ZeroOrNegative(categoryId, nameof(CategoryId));

            Price = price;
            Description = description;
            Contact = contact;
            SuburbId = suburbId;
            CategoryId = categoryId;
            ReferenceId = referenceId;

            Status = JobStatus.Invited;
        }


        public void UpdateStatus(JobStatus jobStatus)
        {
            Status = jobStatus;
        }
    }
}
