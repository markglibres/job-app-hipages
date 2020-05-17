using System;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using BizzPo.Core.Domain;
using Leads.Domain.Entities;
using Leads.Domain.Extensions;
using Leads.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Leads.Domain.Services
{
    public class SuburbService : ISuburbService
    {
        private readonly ILogger<SuburbService> _logger;
        private readonly IDbRepository<Suburb> _repository;

        public SuburbService(
            ILogger<SuburbService> logger,
            IDbRepository<Suburb> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Suburb> Create(int id, string name, string postCode)
        {
            var entity = new Suburb(id, name, postCode);
            var result = await _repository.InsertAsync(entity);

            return result;
        }

        public async Task<bool> IsExists(string name, string postCode)
        {
            Guard.Against.Empty(name, "name");
            Guard.Against.Empty(postCode, "postCode");

            var query = await _repository
                .GetByAsync(r =>
                    r.Where(c =>
                        c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                        && c.PostCode.Equals(postCode, StringComparison.OrdinalIgnoreCase)));

            var result = query.Any();
            return result;
        }
    }
}