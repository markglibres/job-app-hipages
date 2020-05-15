using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HiPages.Presentation.Api.InvitedLeads
{
    [Route("api/leads/invited")]
    [ApiController]
    public class InvitedLeadsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetInvitedLeads()
        {
            var response = new GetInvitedLeadsResponse
            {
                Data = new List<InvitedLeadResponse>
                {
                    new InvitedLeadResponse
                    {
                        Category = "Painters",
                        DateCreated = DateTime.Now,
                        Description = "Need to paint 2 aluminum windows and a sliding glass door",
                        Firstname = "Bill",
                        Id = "5577421",
                        Price = 62,
                        Suburb = "Yanderra 2574"
                    }
                }
            };

            return Ok(response);
        }
    }
}