using System.Collections.Generic;
using MediatR;

namespace Leads.Application.GetInvitedLeads
{
    public class GetInvitedLeadsQuery : IRequest<IEnumerable<GetInvitedLeadsQueryResponse>> { }
}