using System.Collections.Generic;
using System.Linq;
using Leads.Presentation.Api.AcceptedLeads;
using Microsoft.AspNetCore.Http;

namespace Leads.Presentation.Api.Extensions
{
    // haven't tried any existing hal client libraries yet, so for now will do manual 
    // conversion to HAL format
    public static class GetAccepetedLeadsResponseExtensions
    {
        public static dynamic ToHal(
            this GetAccepetedLeadsResponse response,
            HttpRequest request)
        {
            var host = $"{request.Scheme}://{request.Host}";
            var halObject = new Dictionary<string, object>();
            halObject.Add("_links", new Dictionary<string, object>
            {
                {
                    "self",
                    new Dictionary<string, object>
                    {
                        {"href", $"{host}/api/leads/accepted"},
                        {"method", "GET"}
                    }
                }
            });

            halObject.Add("_embedded", new Dictionary<string, object>
            {
                {"leads", response.Data.ToArray()}
            });

            return halObject;
        }
    }
}