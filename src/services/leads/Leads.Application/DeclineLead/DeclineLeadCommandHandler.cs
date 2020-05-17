using System.Threading;
using System.Threading.Tasks;
using Leads.Domain.Constants;
using Leads.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Leads.Application.DeclineLead
{
    public class DeclineLeadCommandHandler : IRequestHandler<DeclineLeadCommand, DeclineLeadCommandResponse>
    {
        private readonly IJobService _jobService;
        private readonly ILogger<DeclineLeadCommandHandler> _logger;

        public DeclineLeadCommandHandler(
            ILogger<DeclineLeadCommandHandler> logger,
            IJobService jobService)
        {
            _logger = logger;
            _jobService = jobService;
        }

        public async Task<DeclineLeadCommandResponse> Handle(DeclineLeadCommand request,
            CancellationToken cancellationToken)
        {
            await _jobService.DeclineJobAsync(request.JobId);
            var response = new DeclineLeadCommandResponse
            {
                IsSuccess = true
            };

            return response;
        }
    }
}