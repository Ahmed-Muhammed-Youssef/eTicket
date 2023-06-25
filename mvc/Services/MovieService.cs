using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Data.Base;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Services
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        private readonly AppDbContext dbContext;

        public MovieService(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Movie?> GetByIdWithInclusionAsync(int id)
        {
            return await dbContext.Movie
                .Include(m => m.Producer)
                .Include(m => m.Cinema)
                .Include(m => m.ActorsMovies).ThenInclude(am => am.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
