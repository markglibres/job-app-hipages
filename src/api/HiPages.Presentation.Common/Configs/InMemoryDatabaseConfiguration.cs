using BizzPo.Core.Domain;
using HiPages.Domain.Contacts;
using HiPages.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HiPages.Presentation.Common.Configs
{
    public static class InMemoryDatabaseConfiguration
    {
        public static void AddInMemoryDatabase(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Contact>, InMemoryContactRepository>();
        }
    }
}