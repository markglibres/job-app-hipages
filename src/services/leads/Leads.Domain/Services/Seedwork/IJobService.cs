using System;
using System.Threading.Tasks;
using Leads.Domain.Entities;

namespace Leads.Domain.Services.Seedwork
{
    public interface IJobService
    {
        Task<Job> CreateAsync( string contactName,
            string contactPhone,
            string contactEmail,
            decimal price,
            string description,
            int suburbId,
            int categoryId,
            Guid referenceId
        );

        Task<Job> DeclineJobAsync( int jobId );
        Task<Job> AcceptJobAsync( int jobId );
        Task<bool> IsExistsAsync( Guid referenceId );
        Task<Job> GetByReferenceIdAsync( Guid referenceId );
        Task<Job> GetByIdAsync( int jobId );
    }
}