using System.Collections.Generic;

namespace HiPages.Presentation.Api.AcceptedLeads
{
    public class GetAccepetedLeadsResponse
    {
        public IEnumerable<AcceptedLeadResponse> Data { get; set; }
    }
}