using mvc.Models;
using System.Linq.Expressions;

namespace mvc.Data.Base
{
    public interface IEntityBaseRepository <T> where T : class, IEntityBase, new()
    {
        // POST
        public Task<T> AddAsync(T entity);
        // GET
        public Task<IEnumerable<T>> GetAllAsync(bool trackChanges = false);
        public Task<IEnumerable<T>> GetAllAsync(bool trackChanges = false, params Expression<Func<T, object?>>[] includeProperties);
        public Task<T?> GetByIdAsync(int id, bool trackChanges = false);
        public Task<T?> GetByIdAsync(int id, bool trackChanges = false, params Expression<Func<T, object?>>[] includeProperties);
        // DELETE
        public Task DeleteAsync(int id);
        // UPDATE 
        public Task<int> UpdateAsync(T entity);
    }
}
