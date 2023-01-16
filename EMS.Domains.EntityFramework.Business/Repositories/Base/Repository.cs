using EMS.Domains.EntityFramework.Entity.Models.Base;
using EMS.Domains.EntityFramework.Entity.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EMS.Domains.EntityFramework.Business.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly EMSContext _context;
        public Repository(EMSContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);

            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, IList<string>? includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();

            if (disableTracking) query = query.AsNoTracking();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null) return await orderBy(query).ToListAsync();

            // query.Include(_context.Companys.Include(c => c.CompanyLevel.GetAncestor(1)).ToString());

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate = null, IList<string>? includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (disableTracking) query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            _context.Entry(entities).State = EntityState.Modified;
            // _context.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }
 
    }
}
