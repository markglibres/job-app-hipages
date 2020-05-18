using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Leads.Domain.Services.Seedwork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Leads.Application.GetInvitedLeads
{
    public class GetInvitedLeadsQueryHandler
        : IRequestHandler<GetInvitedLeadsQuery, IEnumerable<GetInvitedLeadsQueryResponse>>
    {
        private readonly IJobQueryService _jobQueryService;
        private readonly ILogger<GetInvitedLeadsQueryHandler> _logger;

        public GetInvitedLeadsQueryHandler( ILogger<GetInvitedLeadsQueryHandler> logger,
            IJobQueryService jobQueryService
        )
        {
            _logger = logger;
            _jobQueryService = jobQueryService;
        }

        public async Task<IEnumerable<GetInvitedLeadsQueryResponse>> Handle( GetInvitedLeadsQuery request,
            CancellationToken cancellationToken
        )
        {
            var entities = await _jobQueryService.GetInvitedAsync();

            var results = entities
                .Select(
                    e => new GetInvitedLeadsQueryResponse
                    {
                        Id = e.Id,
                        Status = e.JobStatus,
                        CategoryName = e.CategoryName,
                        SuburbName = e.SuburbName,
                        SuburbPostcode = e.SuburbPostcode,
                        ContactName = e.ContactName,
                        Price = e.Price,
                        Description = e.Description,
                        CreatedAt = e.CreatedAt
                    }
                );

            return results;
        }
    }
}