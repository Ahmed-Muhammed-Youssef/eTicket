using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Data.Base;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Services
{
    public class DirectorService : EntityBaseRepository<Director>, IDirectorService
    {
        private readonly AppDbContext _dbContext;
        private readonly IImageUploadService _imageUploadService;

        public DirectorService(AppDbContext dbContext, IImageUploadService imageUploadService)
            :base(dbContext)
        {
            _dbContext = dbContext;
            _imageUploadService = imageUploadService;
        }
        public async Task<Director> UpdateDirectorWithImageAsync(Director director)
        {
            var oldImage = await _dbContext.Directors.Include(a => a.Image)
                .Where(i => i.Id == director.Id)
                .Select(a => a.Image)
                .FirstOrDefaultAsync();
            if (oldImage == null)
            {
                throw new InvalidOperationException("invalid director id");
            }
            if (director.Image.ImageFile == null)
            {
                // without image
                director.ImageId = oldImage.Id;
                await UpdateAsync(director);
                return director;

            }
            // remove old director image from server
            _imageUploadService.Delete(oldImage.ImagePath);

            // add the new image to server
            var imagePath = await _imageUploadService.UploadAsync(director.Image, nameof(Director) + director.FullName!);
            // add the new image path to the director
            director.Image.ImagePath = imagePath;


            // add the new image to the database
            await _dbContext.Images.AddAsync(director.Image);
            await _dbContext.SaveChangesAsync();

            // assign the new image id to the director image id foreign key
            director.ImageId = director.Image.Id;
            _dbContext.Directors.Entry(director).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            // remove old director image from database
            _dbContext.Images.Remove(oldImage);
            await _dbContext.SaveChangesAsync();
            return director;
        }
        public async Task<Director> AddDirectorWithImageUplodaing(Director director)
        {
            var imagePath = await _imageUploadService.UploadAsync(director.Image, nameof(Director) + director.FullName!);

            director.Image.ImagePath = imagePath;
            await _dbContext.Directors.AddAsync(director);
            await _dbContext.SaveChangesAsync();
            return director;
        }
        public async Task DeleteAsyncWithImage(Director director)
        {
            // remove director image from server
            _dbContext.Directors.Remove(director);
            if (director.Image != null)
            {
                // remova director's image from server
                _imageUploadService.Delete(director.Image.ImagePath);
                _dbContext.Images.Remove(director.Image);
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
