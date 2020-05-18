using System;
using Leads.Domain.Entities.Seedwork;
using Newtonsoft.Json;

namespace Leads.Domain.Entities
{
    public class JobInfo : IDbEntity
    {
        [JsonConstructor]
        private JobInfo() { }

        public JobInfo( int jobId,
            Guid referenceId,
            decimal price,
            string description,
            string contactName,
            string contactPhone,
            string contactEmail,
            string suburbName,
            string suburbPostcode,
            string categoryName,
            string jobStatus,
            DateTime createdAt
        )
        {
            JobId = jobId;
            ReferenceId = referenceId;
            Price = price;
            Description = description;
            ContactName = contactName;
            ContactPhone = contactPhone;
            ContactEmail = contactEmail;
            SuburbName = suburbName;
            SuburbPostcode = suburbPostcode;
            CategoryName = categoryName;
            JobStatus = jobStatus;
            CreatedAt = createdAt;
        }

        public int JobId { get; private set; }
        public Guid ReferenceId { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public string ContactName { get; private set; }
        public string ContactPhone { get; private set; }
        public string ContactEmail { get; private set; }
        public string SuburbName { get; private set; }
        public string SuburbPostcode { get; private set; }
        public string CategoryName { get; private set; }
        public string JobStatus { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int Id { get; private set; }

        public void SetStatus( string jobStatus )
        {
            JobStatus = jobStatus;
        }
    }
}