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
        private readonly AppDbContext _dbContext;
        private readonly IImageUploadService _imageUploadService;

        public MovieService(AppDbContext dbContext, IImageUploadService imageUploadService) : base(dbContext)
        {
           _dbContext = dbContext;
           _imageUploadService = imageUploadService;
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
                DirectorId = movieVM.ProducerId,
                CinemaId = movieVM.CinemaId
            };
            movie.Image.ImageFile = movieVM.Image.ImageFile;
            try
            {
                if(movie.Image.ImageFile != null)
                {
                    var imagePath = await _imageUploadService.UploadAsync(movie.Image, nameof(Movie) + movie.Name);
                    movie.Image.ImagePath = imagePath;
                }
                await _dbContext.Movies.AddAsync(movie);
                await _dbContext.SaveChangesAsync();

                // add actorsIds
                var actors = await GetActorsByIds(movieVM.ActorIds);

                foreach (var actor in actors)
                {
                    var actorMovie = new ActorMovie
                    {
                        ActorId = actor.Id,
                        MovieId = movie.Id,
                        Movie = movie,
                        Actor = actor
                    };
                    await _dbContext.AddAsync(actorMovie);
                }
                _dbContext.SaveChanges(); 
            }
            catch (Exception ex)
            {
                await _dbContext.DisposeAsync();
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

            // Remove existing ActorMovies
            var existingActorMovies = oldMovie.ActorsMovies!.Where(am => am.MovieId == oldMovie.Id);
            _dbContext.ActorMovies.RemoveRange(existingActorMovies);
            await _dbContext.SaveChangesAsync();

            oldMovie.Id = movieVM.Id;
            oldMovie.Name = movieVM.Name;
            oldMovie.Price = movieVM.Price;
            oldMovie.Description = movieVM.Description;
            oldMovie.StratDate = movieVM.StratDate;
            oldMovie.EndDate = movieVM.EndDate;
            oldMovie.MovieCategory = movieVM.MovieCategory;
            oldMovie.DirectorId = movieVM.ProducerId;
            oldMovie.CinemaId = movieVM.CinemaId;

            if(movieVM.Image  != null)
            {
                // upload the new image and add it to the database
                var newImage = new Image() { ImageFile = movieVM.Image.ImageFile };
                newImage.ImagePath = await _imageUploadService.UploadAsync(newImage, nameof(Movie) + oldMovie.Name);
                await _dbContext.Images.AddAsync(newImage);
                await _dbContext.SaveChangesAsync();

                // add the new image id to the movie
                oldMovie.ImageId = newImage.Id;

                // delete the old image
                _dbContext.Images.Remove(oldMovie.Image);
                oldMovie.Image = newImage;
            }
            await _dbContext.SaveChangesAsync();

            var actors = await GetActorsByIds(movieVM.ActorIds);
            try
            {
                foreach (var actor in actors)
                {
                    var actorMovie = new ActorMovie
                    {
                        ActorId = actor.Id,
                        MovieId = oldMovie.Id,
                        Movie = oldMovie,
                        Actor = actor
                    };
                    await _dbContext.ActorMovies.AddAsync(actorMovie);
                }
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await _dbContext.DisposeAsync();
                throw new Exception("Failed to add movie, pls try again.", ex);
            }
            return oldMovie;
        }

        public async Task<Movie?> GetByIdWithInclusionAsync(int id)
        {
            var query = _dbContext.Movies.AsQueryable()
                .Include(m => m.Image)
                .Include(m => m.Director)
                .Include(m => m.Cinema)
                .Include(m => m.ActorsMovies)
                .ThenInclude(am => am.Actor)
                .ThenInclude(a => a.Image);

            return await query.FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task RemoveWithImageAsync(int movieId)
        {
            var movie = await _dbContext.Movies
                .Include(m => m.Image)
                .FirstOrDefaultAsync(m => m.Id == movieId);

            if(movie == null)
            {
                throw new InvalidOperationException("invalid movie id");
            }
            _dbContext.Movies.Remove(movie);
            if(movie.Image != null)
            {
                _dbContext.Images.Remove(movie.Image);
                _imageUploadService.Delete(movie.Image.ImagePath);
            }
            await _dbContext.SaveChangesAsync();
        }
        // utility
        private async Task<IEnumerable<Actor>> GetActorsByIds(IEnumerable<int> ids)
        {
            var result = new List<Actor>();
            foreach (var id in ids)
            {
                var a = await _dbContext.Actors.FindAsync(id);
                if (a != null)
                {
                    result.Add(a);
                }
                // you can specify what to do with invalid ids here
            }
            return result;
        }
    }
}
