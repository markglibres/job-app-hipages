using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Leads.Domain.Services.Seedwork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Leads.Application.GetAcceptedLeads
{
    public class GetAcceptedLeadsQueryHandler
        : IRequestHandler<GetAcceptedLeadsQuery, IEnumerable<GetAcceptedLeadsQueryResponse>>
    {
        private readonly IJobQueryService _jobQueryService;
        private readonly ILogger<GetAcceptedLeadsQueryHandler> _logger;

        public GetAcceptedLeadsQueryHandler(
            ILogger<GetAcceptedLeadsQueryHandler> logger,
            IJobQueryService jobQueryService)
        {
            _logger = logger;
            _jobQueryService = jobQueryService;
        }

        public async Task<IEnumerable<GetAcceptedLeadsQueryResponse>> Handle(GetAcceptedLeadsQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await _jobQueryService.GetAcceptedAsync();

            var results = entities
                .Select(e => new GetAcceptedLeadsQueryResponse
                {
                    Id = e.Id,
                    Status = e.JobStatus,
                    CategoryName = e.CategoryName,
                    SuburbName = e.SuburbName,
                    SuburbPostcode = e.SuburbPostcode,
                    ContactName = e.ContactName,
                    ContactPhone = e.ContactPhone,
                    ContactEmail = e.ContactEmail,
                    Price = e.Price,
                    Description = e.Description,
                    CreatedAt = e.CreatedAt
                });

            return results;
        }
    }
}