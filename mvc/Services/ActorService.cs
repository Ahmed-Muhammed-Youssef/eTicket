using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Services
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext _context;

        public ActorService(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<Actor> AddAsync(Actor actor)
        {
            await _context.Actor.AddAsync(actor);
            _context.SaveChanges();
            return actor;
        }

        public async Task DeleteAsync(int id)
        {
            var actor = await _context.Actor.FindAsync(id);
            if(actor != null)
            {
                _context.Actor.Remove(actor);
                await _context.SaveChangesAsync();
            }
            throw new Exception($"Invalid Id: {id}");
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            return await _context.Actor.ToListAsync();
        }

        public async Task<Actor?> GetByIdAsync(int id)
        {
            return await _context.Actor.FindAsync(id);
        }

        public async Task<int> UpdateAsync(Actor actor)
        {
            _context.Actor.Entry(actor).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
