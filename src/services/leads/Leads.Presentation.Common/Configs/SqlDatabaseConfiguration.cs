using BizzPo.Core.Domain;
using Leads.Domain.Contacts;
using Leads.Infrastructure.Repositories;
using Leads.Infrastructure.Repositories.EfSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leads.Presentation.Common.Configs
{
    public static class SqlDatabaseConfiguration
    {
        public static void AddSqlDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContactsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IRepository<Contact>, ContactsRepository>();
        }
    }
}