﻿using System;
using System.Threading.Tasks;
using Leads.Domain.Constants;
using Leads.Domain.Entities;

namespace Leads.Domain.Services
{
    public interface IJobService
    {
        Task<Job> CreateAsync(
            string contactName,
            string contactPhone,
            string contactEmail,
            decimal price,
            string description,
            int suburbId,
            int categoryId,
            Guid referenceId);

        Task<Job> DeclineJobAsync(int jobId);
        Task<Job> AcceptJobAsync(int jobId);
        Task<bool> IsExistsAsync(Guid referenceId);
        Task<Job> GetByReferenceId(Guid referenceId);
    }
}