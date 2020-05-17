using BizzPo.Core.Domain;
using Leads.Domain.Contacts;
using Leads.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Leads.Presentation.Common.Configs
{
    public static class InMemoryDatabaseConfiguration
    {
        public static void AddInMemoryDatabase(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Contact>, InMemoryContactRepository>();
        }
    }
}