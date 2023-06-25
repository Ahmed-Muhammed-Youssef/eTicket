using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Data.Base;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Services
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        private readonly AppDbContext _dbContext;

        public MovieService(AppDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Movie>> GetAllWithCinemaAsync()
        {
            return await _dbContext.Movie
                .Include(m => m.Cinema)
                .ToListAsync(); 
        }
    }
}
