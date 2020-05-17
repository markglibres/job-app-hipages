using System;
using System.Collections.Generic;
using Leads.Domain.Entities;
using Leads.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Leads.Presentation.Api.Seed
{
    public static class SeedSuburbs
    {
        public static void EnsureSeedData(IServiceProvider services)
        {
            var service = services.GetService<ISuburbService>();

            foreach (var data in SeedData())
            {
                var isExists = service.IsExists(data.Name, data.PostCode)
                    .Result;
                if (isExists) continue;

                service
                    .Create(data.Id, data.Name, data.PostCode)
                    .Wait();
            }
        }

        private static IEnumerable<Suburb> SeedData()
        {
            return new List<Suburb>
            {
                new Suburb(1, "Sydney", "2000"),
                new Suburb(2, "Bondi", "2026"),
                new Suburb(3, "Manly", "2095"),
                new Suburb(4, "Surry Hills", "2010"),
                new Suburb(5, "Newtown", "2042")
            };
        }
    }
}