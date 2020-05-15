using System;
using MediatR;

namespace HiPages.Application.Queries.GetContact
{
    public class GetContactQuery : IRequest<GetContactQueryResponse>
    {
        public Guid ContactId { get; set; }
    }
}