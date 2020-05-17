using MediatR;

namespace Leads.Application.DeclineLead
{
    public class DeclineLeadCommand : IRequest<DeclineLeadCommandResponse>
    {
        public int JobId { get; set; }
    }
}