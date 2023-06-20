using Microsoft.AspNetCore.Mvc.ViewFeatures;
using mvc.Models;

namespace mvc.Interfaces
{
    public interface IActorService
    {

        // POST
        public Task<Actor> AddAsync(Actor actor);
        // GET
        public Task<IEnumerable<Actor>> GetAllAsync();
        public Task<Actor?> GetByIdAsync(int id);
        // DELETE
        public Task DeleteAsync(int id);
        // UPDATE 
        public Task<int> UpdateAsync(Actor actor);

    }
}
