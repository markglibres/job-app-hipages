using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiPages.Presentation.Api.Seedwork.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace HiPages.Presentation.Api.AcceptedLeads
{
    [Route("api/leads/accepted")]
    [ApiController]
    public class AcceptedLeadsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAccepted()
        {
            var response = new GetAccepetedLeadsResponse
            {
                Data = new List<AcceptedLeadResponse>
                {
                    new AcceptedLeadResponse
                    {
                        Category = "General Building Work",
                        DateCreated = DateTime.Now,
                        Description = "Plaster exposed brick walls (see photos), " +
                                      "square off 2 archways (see photos), " +
                                      "and expand pantry (see photos)",
                        Firstname = "Pete",
                        Id = "5141895",
                        Price = 26,
                        Suburb = "Caramar 6031",
                        Contact = new Contact
                        {
                            Email = "fake@malinator.com",
                            Fullname = "Pete",
                            Phone = "0412345678"
                        }
                    }
                }
            };

            return Ok(response);
        }
    }
}