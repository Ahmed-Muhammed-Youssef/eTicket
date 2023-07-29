using mvc.Data.Base;
using mvc.Models;

namespace mvc.Interfaces
{
    public interface IActorService : IEntityBaseRepository<Actor>
    {
        public Task<Actor> AddActorWithImageUplodaing(Actor actor);
        public Task<Actor> UpdateActorWithImageAsync(Actor actor);
    }
}
