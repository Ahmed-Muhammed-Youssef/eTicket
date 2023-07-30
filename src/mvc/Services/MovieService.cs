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
                DirectorId = movieVM.ProducerId,
                CinemaId = movieVM.CinemaId
            };
            try
            {
                await dbContext.Movies.AddAsync(movie);
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

        public async Task<Movie?> UpdateMovieVMAsync(MovieVM movieVM)
        {

            var oldMovie = await GetByIdWithInclusionAsync(movieVM.Id);
            if(oldMovie == null)
            {
                return null;
            }

            //Rremove existing ActorMovies
            var existingActorMovies = oldMovie.ActorsMovies!.Where(am => am.MovieId == oldMovie.Id);
            dbContext.ActorMovies.RemoveRange(existingActorMovies);
            await dbContext.SaveChangesAsync();

            oldMovie.Id = movieVM.Id;
            oldMovie.Name = movieVM.Name;
            oldMovie.Price = movieVM.Price;
            oldMovie.Description = movieVM.Description;
            oldMovie.StratDate = movieVM.StratDate;
            oldMovie.EndDate = movieVM.EndDate;
            oldMovie.MovieCategory = movieVM.MovieCategory;
            oldMovie.ImageUrl = movieVM.ImageUrl;
            oldMovie.DirectorId = movieVM.ProducerId;
            oldMovie.CinemaId = movieVM.CinemaId;
            await dbContext.SaveChangesAsync();
            try
            {
                foreach (var actorId in movieVM.ActorIds)
                {
                    var actorMovie = new ActorMovie
                    {
                        ActorId = actorId,
                        MovieId = oldMovie.Id
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
            return oldMovie;
        }

        public async Task<Movie?> GetByIdWithInclusionAsync(int id)
        {
            return await dbContext.Movies
                .Include(m => m.Director)
                .Include(m => m.Cinema)
                .Include(m => m.ActorsMovies).ThenInclude(am => am.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
