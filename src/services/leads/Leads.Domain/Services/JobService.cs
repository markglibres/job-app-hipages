using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using BizzPo.Core.Domain;
using Leads.Domain.Constants;
using Leads.Domain.Entities;
using Leads.Domain.Extensions;
using Leads.Domain.Repositories;
using Leads.Domain.Services.Seedwork;
using Leads.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Leads.Domain.Services
{
    public class JobService : IJobService
    {
        private readonly IEnumerable<IDiscountService> _discountServices;
        private readonly IDomainEventsService _domainEventsService;
        private readonly ILogger<JobService> _logger;
        private readonly IDbRepository<Job> _repository;

        public JobService( ILogger<JobService> logger,
            IDbRepository<Job> repository,
            IDomainEventsService domainEventsService,
            IEnumerable<IDiscountService> discountServices
        )
        {
            _logger = logger;
            _repository = repository;
            _domainEventsService = domainEventsService;
            _discountServices = discountServices;
        }

        public async Task<Job> CreateAsync( string contactName,
            string contactPhone,
            string contactEmail,
            decimal price,
            string description,
            int suburbId,
            int categoryId,
            Guid referenceId
        )
        {
            var contact = new Contact( contactName, contactPhone, contactEmail );

            var entity = new Job(
                price,
                description,
                contact,
                suburbId,
                categoryId,
                referenceId
            );

            var result = await _repository.InsertAsync( entity );

            await _domainEventsService.Publish( entity.Events, CancellationToken.None );

            return result;
        }

        public async Task<Job> DeclineJobAsync( int jobId )
        {
            var entity = await GetByIdAsync( jobId );
            entity.Decline();

            var result = await _repository.SaveAsync( entity );

            await _domainEventsService.Publish( entity.Events, CancellationToken.None );

            return result;
        }

        public async Task<Job> AcceptJobAsync( int jobId )
        {
            var entity = await GetByIdAsync( jobId );
            
            foreach ( var discountService in _discountServices )
            {
                discountService.ApplyDiscount( entity );
            }

            entity.Accept();
            var result = await _repository.SaveAsync( entity );

            await _domainEventsService.Publish( entity.Events, CancellationToken.None );

            return result;
        }

        public async Task<bool> IsExistsAsync( Guid referenceId )
        {
            Guard.Against.Empty( referenceId, "referenceId" );

            var query = await _repository
                .GetByAsync(
                    r =>
                        r.Where(
                            c =>
                                c.ReferenceId.Equals( referenceId )
                        )
                );

            var result = query.Any();

            return result;
        }

        public async Task<Job> GetByReferenceIdAsync( Guid referenceId )
        {
            Guard.Against.Empty( referenceId, "referenceId" );

            var query = await _repository
                .GetByAsync(
                    r =>
                        r.Where(
                            c =>
                                c.ReferenceId.Equals( referenceId )
                        )
                );

            var result = query.FirstOrDefault();

            return result;
        }

        public async Task<Job> GetByIdAsync( int jobId )
        {
            Guard.Against.ZeroOrNegative( jobId, "jobId" );

            var entity = await _repository.GetSingleAsync( e => e.Id == jobId );

            if ( entity == null )
            {
                throw new DomainException( $"Cannot find job with id {jobId}" );
            }

            return entity;
        }
    }
}