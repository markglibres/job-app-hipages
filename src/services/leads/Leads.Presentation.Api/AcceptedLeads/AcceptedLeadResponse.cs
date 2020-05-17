using Leads.Presentation.Api.Seedwork.Contacts;
using Leads.Presentation.Api.Seedwork.Leads;

namespace Leads.Presentation.Api.AcceptedLeads
{
    public class AcceptedLeadResponse : LeadResponse
    {
        public Contact Contact { get; set; }
    }
}