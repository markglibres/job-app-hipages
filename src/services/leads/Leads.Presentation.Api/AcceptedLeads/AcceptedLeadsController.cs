using System.Linq;
using System.Threading.Tasks;
using Leads.Application.AcceptLead;
using Leads.Application.GetAcceptedLeads;
using Leads.Presentation.Api.Extensions;
using Leads.Presentation.Api.Seedwork.Contacts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Leads.Presentation.Api.AcceptedLeads
{
    [Route( "api/leads/accepted" )]
    [ApiController]
    public class AcceptedLeadsController : ControllerBase
    {
        private readonly ILogger<AcceptedLeadsController> _logger;
        private readonly IMediator _mediator;

        public AcceptedLeadsController( ILogger<AcceptedLeadsController> logger,
            IMediator mediator
        )
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccepted()
        {
            var query = new GetAcceptedLeadsQuery();
            var response = await _mediator.Send( query );


            var httpResponse = new GetAccepetedLeadsResponse
            {
                Data = response
                    .Select(
                        e => new AcceptedLeadResponse
                        {
                            Category = e.CategoryName,
                            DateCreated = e.CreatedAt,
                            Description = e.Description,
                            Id = e.Id.ToString(),
                            Price = e.Price,
                            Suburb = $"{e.SuburbName} ${e.SuburbPostcode}",
                            Contact = new Contact
                            {
                                Email = e.ContactEmail,
                                Fullname = e.ContactName,
                                Phone = e.ContactPhone
                            }
                        }
                    )
            };

            return Ok( httpResponse.ToHal( HttpContext.Request ) );
        }

        [HttpPost]
        [Route( "{id}" )]
        public async Task<IActionResult> AcceptInvitedLead( [FromRoute] int id )
        {
            var command = new AcceptLeadCommand { JobId = id };

            await _mediator.Send( command );

            return Ok();
        }
    }
}