using System;

namespace Leads.Presentation.Api.Seedwork.Leads
{
    public interface ILeadResponse
    {
        string Id { get; set; }
        DateTime DateCreated { get; set; }
        string Suburb { get; set; }
        string Category { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
    }
}
