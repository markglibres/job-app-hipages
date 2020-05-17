using System.Threading;
using System.Threading.Tasks;
using Leads.Domain.Constants;
using Leads.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Leads.Application.AcceptLead
{
    public class AcceptLeadCommandHandler : IRequestHandler<AcceptLeadCommand, AcceptLeadCommandResponse>
    {
        private readonly IJobService _jobService;
        private readonly ILogger<AcceptLeadCommandHandler> _logger;

        public AcceptLeadCommandHandler(
            ILogger<AcceptLeadCommandHandler> logger,
            IJobService jobService)
        {
            _logger = logger;
            _jobService = jobService;
        }

        public async Task<AcceptLeadCommandResponse> Handle(AcceptLeadCommand request,
            CancellationToken cancellationToken)
        {
            await _jobService.AcceptJobAsync(request.JobId);
            var response = new AcceptLeadCommandResponse
            {
                IsSuccess = true
            };

            return response;
        }
    }
}