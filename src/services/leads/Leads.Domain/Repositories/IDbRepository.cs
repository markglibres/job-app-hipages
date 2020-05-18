using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Leads.Domain.Entities.Seedwork;

namespace Leads.Domain.Repositories
{
    public interface IDbRepository<T>
        where T : IDbEntity
    {
        Task<T> InsertAsync( T entity );
        Task<T> SaveAsync( T entity );
        Task<T> GetSingleAsync( Expression<Func<T, bool>> filter );
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> GetByAsync( Func<IQueryable<T>, IQueryable<T>> filter );
        Task DeleteAsync( T entity );
    }
}