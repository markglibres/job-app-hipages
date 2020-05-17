using System;

namespace Leads.Presentation.Api.Seedwork.Leads
{
    public abstract class LeadResponse : ILeadResponse
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public DateTime DateCreated { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
