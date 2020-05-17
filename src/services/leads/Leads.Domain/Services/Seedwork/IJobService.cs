using System;
using System.Threading.Tasks;
using Leads.Domain.Constants;
using Leads.Domain.Entities;

namespace Leads.Domain.Services
{
    public interface IJobService
    {
        Task<Job> Create(
            string contactName,
            string contactPhone,
            string contactEmail,
            decimal price,
            string description,
            int suburbId,
            int categoryId,
            Guid referenceId);

        Task<Job> SetStatus(int jobId, JobStatus jobStatus);
        Task<bool> IsExists(Guid referenceId);
    }
}