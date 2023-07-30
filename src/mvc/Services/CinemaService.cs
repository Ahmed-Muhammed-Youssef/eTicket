using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Data.Base;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Services
{
    public class CinemaService : EntityBaseRepository<Cinema>, ICinemaService
    {
        private readonly AppDbContext _dbContext;
        private readonly IImageUploadService _imageUploadService;

        public CinemaService(AppDbContext dbContext, IImageUploadService imageUploadService) : base(dbContext)
        {
            _dbContext = dbContext;
            _imageUploadService = imageUploadService;
        }
        public async Task<Cinema> UpdateWithImageAsync(Cinema cinema)
        {
            var oldImage = await _dbContext.Cinemas.Include(a => a.Image)
                .Where(i => i.Id == cinema.Id)
                .Select(a => a.Image)
                .FirstOrDefaultAsync();
            if (oldImage == null)
            {
                throw new InvalidOperationException("invalid cinema id");
            }
            if (cinema.Image.ImageFile == null)
            {
                // without image
                cinema.ImageId = oldImage.Id;
                await UpdateAsync(cinema);
                return cinema;

            }
            // remove old cinema image from server
            _imageUploadService.Delete(oldImage.ImagePath);

            // add the new image to server
            var imagePath = await _imageUploadService.UploadAsync(cinema.Image, nameof(Cinema) + cinema.Name!);
            // add the new image path to the cinema
            cinema.Image.ImagePath = imagePath;


            // add the new image to the database
            await _dbContext.Images.AddAsync(cinema.Image);
            await _dbContext.SaveChangesAsync();

            // assign the new image id to the cinema image id foreign key
            cinema.ImageId = cinema.Image.Id;
            _dbContext.Cinemas.Entry(cinema).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            // remove old cinema image from database
            _dbContext.Images.Remove(oldImage);
            await _dbContext.SaveChangesAsync();
            return cinema;
        }
        public async Task<Cinema> AddWithImageUplodaing(Cinema cinema)
        {
            var imagePath = await _imageUploadService.UploadAsync(cinema.Image, nameof(Cinema) + cinema.Name!);

            cinema.Image.ImagePath = imagePath;
            await _dbContext.Cinemas.AddAsync(cinema);
            await _dbContext.SaveChangesAsync();
            return cinema;
        }
        public async Task DeleteAsyncWithImage(Cinema cinema)
        {
            // remove cinema image from server
            _dbContext.Cinemas.Remove(cinema);
            if (cinema.Image != null)
            {
                // remova cinema's image from server
                _imageUploadService.Delete(cinema.Image.ImagePath);
                _dbContext.Images.Remove(cinema.Image);
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
