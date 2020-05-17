using System;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using BizzPo.Core.Domain;
using Leads.Domain.Constants;
using Leads.Domain.Entities;
using Leads.Domain.Extensions;
using Leads.Domain.Repositories;
using Leads.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Leads.Domain.Services
{
    public class JobService : IJobService
    {
        private readonly ILogger<JobService> _logger;
        private readonly IDbRepository<Job> _repository;

        public JobService(
            ILogger<JobService> logger,
            IDbRepository<Job> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Job> Create(
            string contactName,
            string contactPhone,
            string contactEmail,
            decimal price,
            string description,
            int suburbId,
            int categoryId,
            Guid referenceId)
        {
            var contact = new Contact(contactName, contactPhone, contactEmail);
            var entity = new Job(price, description, contact, suburbId, categoryId, referenceId);

            var result = await _repository.InsertAsync(entity);

            return result;
        }

        public async Task<Job> SetStatus(int jobId, JobStatus jobStatus)
        {
            Guard.Against.ZeroOrNegative(jobId, "jobId");

            var entity = await _repository.GetSingleAsync(e => e.Id == jobId);

            if (entity == null) throw new DomainException($"Cannot find job with id {jobId}");

            entity.UpdateStatus(jobStatus);
            var result = await _repository.SaveAsync(entity);

            return result;
        }

        public async Task<bool> IsExists(Guid referenceId)
        {
            Guard.Against.Empty(referenceId, "referenceId");

            var query = await _repository
                .GetByAsync(r =>
                    r.Where(c =>
                        c.ReferenceId.Equals(referenceId)));
            var result = query.Any();

            return result;
        }
    }
}