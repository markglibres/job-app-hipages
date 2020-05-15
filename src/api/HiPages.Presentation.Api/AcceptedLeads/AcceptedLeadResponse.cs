using HiPages.Presentation.Api.Seedwork.Contacts;
using HiPages.Presentation.Api.Seedwork.Leads;

namespace HiPages.Presentation.Api.AcceptedLeads
{
    public class AcceptedLeadResponse : LeadResponse
    {
        public Contact Contact { get; set; }
    }
}