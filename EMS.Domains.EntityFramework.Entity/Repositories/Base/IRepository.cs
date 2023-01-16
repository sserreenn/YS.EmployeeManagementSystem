using EMS.Domains.EntityFramework.Entity.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domains.EntityFramework.Entity.Repositories.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, IList<string>? includes = null, bool disableTracking = true);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate = null, IList<string>? includes = null, bool disableTracking = true);

        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}
