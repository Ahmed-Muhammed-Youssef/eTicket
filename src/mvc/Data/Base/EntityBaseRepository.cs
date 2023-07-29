using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace mvc.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
        where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _dbContext;

        public EntityBaseRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            if(entity == null)
            {
                throw new NullReferenceException(nameof(entity));
            }
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool trackChanges = false)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if(!trackChanges)
            {
                query.AsNoTracking();
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool trackChanges = false, params Expression<Func<T, object?>>[] includeProperties)
        {
            var query = _dbContext.Set<T>().AsQueryable<T>();
            if (!trackChanges)
            {
                query.AsNoTracking();
            }
            query = includeProperties.Aggregate(query, (current, includeProperties) => current.Include(includeProperties));
            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync( int id, bool trackChanges = false)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (!trackChanges)
            {
                query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T?> GetByIdAsync(int id, bool trackChanges = false, params Expression<Func<T, object?>>[] includeProperties)
        {
            var query = _dbContext.Set<T>().AsQueryable<T>();
            if (!trackChanges)
            {
                query.AsNoTracking();
            }
            query = includeProperties
               .Aggregate(query,
               (current, includeProperties) => current.Include(includeProperties));
            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
    }
}
