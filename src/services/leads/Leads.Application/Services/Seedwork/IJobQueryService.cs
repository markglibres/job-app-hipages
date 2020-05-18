using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leads.Application.Services.JobQuery;

namespace Leads.Application.Services.Seedwork
{
    public interface IJobQueryService
    {
        Task InsertJobAsync( int jobId,
            Guid referenceId,
            decimal price,
            string description,
            string contactName,
            string contactPhone,
            string contactEmail,
            string suburbName,
            string suburbPostcode,
            string categoryName,
            string jobStatus,
            DateTime createdAt
        );

        Task<IEnumerable<JobInfo>> GetInvitedAsync();
        Task<IEnumerable<JobInfo>> GetAcceptedAsync();
        Task UpdateJobAsync(Guid referenceId, decimal price, string jobStatus);
    }
}