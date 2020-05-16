using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiPages.Presentation.Api.Extensions;
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

            // for now let's create our own HAL converter
            // TODO: find a better way to do this, such as dotnetcore client library for HAL json
            return Ok(response.ToHal(HttpContext.Request));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeclineInvitedLead([FromRoute] string id)
        {
            Console.WriteLine("Lead declined");
            return Ok();
        }
    }
}