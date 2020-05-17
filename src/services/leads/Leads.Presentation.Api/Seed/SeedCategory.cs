using System;
using System.Collections.Generic;
using Leads.Domain.Entities;
using Leads.Domain.Repositories;
using Leads.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Leads.Presentation.Api.Seed
{
    public static class SeedCategory
    {
        public static void EnsureSeedData(IServiceProvider services)
        {
            var service = services.GetService<ICategoryService>();

            foreach (var category in SeedData())
            {
                var isExists = service.IsExistsAsync(category.Name, category.ParentCategoryId)
                    .Result;
                if (isExists) continue;

                service
                    .CreateAsync(category.Id, category.Name, category.ParentCategoryId)
                    .Wait();
            }
        }

        private static IEnumerable<Category> SeedData()
        {
            return new List<Category>
            {
                new Category(1, "Plumbing", 0),
                new Category(2, "Electrical", 0),
                new Category(3, "Carpentry", 0),
                new Category(4, "Handyman", 0),
                new Category(5, "Building", 0),
                new Category(6, "Bathroom Renovation", 5)
            };
        }
    }
}