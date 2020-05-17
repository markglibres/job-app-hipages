using MediatR;

namespace Leads.Application.AcceptLead
{
    public class AcceptLeadCommand : IRequest<AcceptLeadCommandResponse>
    {
        public int JobId { get; set; }
    }
}