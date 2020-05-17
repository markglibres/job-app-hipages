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
    public class CategoryService : ICategoryService
    {
        private readonly ILogger<CategoryService> _logger;
        private readonly IDbRepository<Category> _repository;

        public CategoryService(
            ILogger<CategoryService> logger,
            IDbRepository<Category> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Category> CreateAsync(int id, string name, int parentCategoryId)
        {
            var category = new Category(id, name, parentCategoryId);
            var result = await _repository.InsertAsync(category);
            return result;
        }

        public async Task<bool> IsExistsAsync(string name, int parentCategoryId)
        {
            Guard.Against.Empty(name, "name");

            var query = await _repository
                .GetByAsync(r =>
                    r.Where(c =>
                        c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                        && c.ParentCategoryId == parentCategoryId));
            var result = query.Any();

            return result;
        }
    }
}