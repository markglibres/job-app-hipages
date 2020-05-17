using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Leads.Domain.Entities.Seedwork;
using Leads.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Leads.Infrastructure.MySqlDatabase.Repositories
{
    public abstract class MySqlDbRepository<T> : IDbRepository<T>
        where T : class, IDbEntity
    {
        protected readonly DbContext DbContext;

        protected MySqlDbRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>().AsQueryable();
        }

        public virtual async Task<IEnumerable<T>> GetByAsync(Func<IQueryable<T>, IQueryable<T>> filter)
        {
            var filtered = filter(DbContext.Set<T>());
            return await filtered.ToListAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter)
        {
            return await DbContext.Set<T>().FirstOrDefaultAsync(filter);
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            await DbContext.Set<T>().AddAsync(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> SaveAsync(T entity)
        {
            DbContext.Set<T>().Update(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }
    }
}