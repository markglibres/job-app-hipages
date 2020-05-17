using System.Collections.Generic;

namespace Leads.Presentation.Api.InvitedLeads
{
    public class GetInvitedLeadsResponse
    {
        public IEnumerable<InvitedLeadResponse> Data { get; set; }
    }
}