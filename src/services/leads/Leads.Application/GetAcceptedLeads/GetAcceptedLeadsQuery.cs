using System.Collections.Generic;
using MediatR;

namespace Leads.Application.GetAcceptedLeads
{
    public class GetAcceptedLeadsQuery : IRequest<IEnumerable<GetAcceptedLeadsQueryResponse>>
    {
    }
}