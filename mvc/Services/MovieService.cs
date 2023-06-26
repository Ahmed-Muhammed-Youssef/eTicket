using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Data.Base;
using mvc.Data.ViewModels;
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

        public async Task<Movie> AddMovieVMAsync(MovieVM movieVM)
        {
            var movie = new Movie
            {
                Name = movieVM.Name,
                Price = movieVM.Price,
                Description = movieVM.Description,
                StratDate = movieVM.StratDate,
                EndDate = movieVM.EndDate,
                MovieCategory = movieVM.MovieCategory,
                ImageUrl = movieVM.ImageUrl,
                ProducerId = movieVM.ProducerId,
                CinemaId = movieVM.CinemaId
            };
            try
            {
                await dbContext.Movie.AddAsync(movie);
                dbContext.SaveChanges(); 
                foreach (var actorId in movieVM.ActorIds)
                {
                    var actorMovie = new ActorMovie
                    {
                        ActorId = actorId,
                        MovieId = movie.Id
                    };
                    await dbContext.AddAsync(actorMovie);
                }
                dbContext.SaveChanges(); 
            }
            catch (Exception ex)
            {
                await dbContext.DisposeAsync();
                throw new Exception("Failed to add movie, pls try again.", ex);
            }
            return movie;
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
