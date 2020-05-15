using System.Collections.Generic;

namespace HiPages.Presentation.Api.InvitedLeads
{
    public class GetInvitedLeadsResponse
    {
        public IEnumerable<InvitedLeadResponse> Data { get; set; }
    }
}