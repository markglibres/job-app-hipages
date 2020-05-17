using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leads.Domain.Entities;

namespace Leads.Domain.Services.Seedwork
{
    public interface IJobQueryService
    {
        Task InsertJobAsync(
            int jobId,
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
            DateTime createdAt);
        Task<IEnumerable<JobInfo>> GetInvitedAsync();
        Task<IEnumerable<JobInfo>> GetAcceptedAsync();
        Task UpdateStatus(Guid referenceId, string jobStatus);
    }
}