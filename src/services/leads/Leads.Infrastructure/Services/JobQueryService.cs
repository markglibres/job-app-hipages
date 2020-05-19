using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leads.Domain.Constants;
using Leads.Domain.Entities;
using Leads.Domain.Repositories;
using Leads.Domain.Services.Seedwork;
using Microsoft.Extensions.Logging;

namespace Leads.Infrastructure.Services
{
    // Ideally, we should not be using EFcore for queries,
    // but rather a small ORM with custom select statement
    // but for demo purposes, let's use EF core
    public class JobQueryService : IJobQueryService
    {
        private readonly ILogger<JobQueryService> _logger;
        private readonly IDbRepository<JobInfo> _repository;

        public JobQueryService( ILogger<JobQueryService> logger,
            IDbRepository<JobInfo> repository
        )
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task InsertJobAsync( int jobId,
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
        )
        {
            var entity = new JobInfo(
                jobId,
                referenceId,
                price,
                description,
                contactName,
                contactPhone,
                contactEmail,
                suburbName,
                suburbPostcode,
                categoryName,
                jobStatus,
                createdAt
            );

            await _repository.InsertAsync( entity );
        }

        public async Task<IEnumerable<JobInfo>> GetInvitedAsync() => await GetByStatusAsync( JobStatus.New );

        public async Task<IEnumerable<JobInfo>> GetAcceptedAsync() => await GetByStatusAsync( JobStatus.Accepted );

        public async Task UpdateJobAsync( Guid referenceId, decimal price, string jobStatus)
        {
            var entity = await _repository.GetSingleAsync( e => e.ReferenceId.Equals( referenceId ) );
            entity.SetPrice( price );
            entity.SetStatus( jobStatus );

            await _repository.SaveAsync( entity );
        }

        private async Task<IEnumerable<JobInfo>> GetByStatusAsync( JobStatus jobStatus )
        {
            var entities = await _repository.GetByAsync(
                e =>
                    e.Where( j => j.JobStatus.Equals( jobStatus.ToString(), StringComparison.OrdinalIgnoreCase ) )
            );

            return entities;
        }
    }
}