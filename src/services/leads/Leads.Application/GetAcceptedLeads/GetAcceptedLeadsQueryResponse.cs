using System;

namespace Leads.Application.GetAcceptedLeads
{
    public class GetAcceptedLeadsQueryResponse
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string CategoryName { get; set; }
        public string SuburbName { get; set; }
        public string SuburbPostcode { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
