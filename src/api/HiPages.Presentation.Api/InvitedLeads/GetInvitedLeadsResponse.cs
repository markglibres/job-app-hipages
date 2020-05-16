using System.Collections.Generic;
using Halcyon.HAL.Attributes;

namespace HiPages.Presentation.Api.InvitedLeads
{
    public class GetInvitedLeadsResponse
    {
        public IEnumerable<InvitedLeadResponse> Data { get; set; }
    }
}