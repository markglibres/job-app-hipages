using System.Collections.Generic;

namespace Leads.Presentation.Api.AcceptedLeads
{
    public class GetAccepetedLeadsResponse
    {
        public IEnumerable<AcceptedLeadResponse> Data { get; set; }
    }
}