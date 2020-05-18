using System.Linq;
using System.Threading.Tasks;
using Leads.Application.DeclineLead;
using Leads.Application.GetInvitedLeads;
using Leads.Presentation.Api.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Leads.Presentation.Api.InvitedLeads
{
    [Route( "api/leads/invited" )]
    [ApiController]
    public class InvitedLeadsController : ControllerBase
    {
        private readonly ILogger<InvitedLeadsController> _logger;
        private readonly IMediator _mediator;

        public InvitedLeadsController( ILogger<InvitedLeadsController> logger,
            IMediator mediator
        )
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetInvitedLeads()
        {
            var query = new GetInvitedLeadsQuery();
            var response = await _mediator.Send( query );

            var httpResponse = new GetInvitedLeadsResponse
            {
                Data = response
                    .Select(
                        e => new InvitedLeadResponse
                        {
                            Category = e.CategoryName,
                            DateCreated = e.CreatedAt,
                            Description = e.Description,
                            Firstname = e.ContactName.Split( ' ' )[0],
                            Id = e.Id.ToString(),
                            Price = e.Price,
                            Suburb = $"{e.SuburbName} {e.SuburbPostcode}"
                        }
                    )
            };

            // for now let's create our own HAL converter
            // TODO: find a better way to do this, such as dotnetcore client library for HAL json
            return Ok( httpResponse.ToHal( HttpContext.Request ) );
        }

        [HttpDelete]
        [Route( "{id}" )]
        public async Task<IActionResult> DeclineInvitedLead( [FromRoute] int id )
        {
            var command = new DeclineLeadCommand { JobId = id };

            await _mediator.Send( command );

            return Ok();
        }
    }
}