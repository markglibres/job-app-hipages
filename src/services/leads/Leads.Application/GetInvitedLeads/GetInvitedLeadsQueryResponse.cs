using System;

namespace Leads.Application.GetInvitedLeads
{
    public class GetInvitedLeadsQueryResponse
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string CategoryName { get; set; }
        public string SuburbName { get; set; }
        public string SuburbPostcode { get; set; }
        public string ContactName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}