using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Data.Base;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Services
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducerService
    {
        private readonly AppDbContext _dbContext;
        private readonly IImageUploadService _imageUploadService;

        public ProducerService(AppDbContext dbContext, IImageUploadService imageUploadService)
            :base(dbContext)
        {
            this._dbContext = dbContext;
            this._imageUploadService = imageUploadService;
        }
        public async Task<Producer> UpdateProducerWithImageAsync(Producer producer)
        {
            var oldImage = await _dbContext.Producer.Include(a => a.Image)
                .Where(i => i.Id == producer.Id)
                .Select(a => a.Image)
                .FirstOrDefaultAsync();
            if (oldImage == null)
            {
                throw new InvalidOperationException("invalid producer id");
            }
            if (producer.Image.ImageFile == null)
            {
                // without image
                producer.ImageId = oldImage.Id;
                await UpdateAsync(producer);
                return producer;

            }
            // remove old producer image from server
            _imageUploadService.Delete(oldImage.ImagePath);

            // add the new image to server
            var imagePath = await _imageUploadService.UploadAsync(producer.Image, nameof(Producer) + producer.FullName!);
            // add the new image path to the producer
            producer.Image.ImagePath = imagePath;


            // add the new image to the database
            await _dbContext.Image.AddAsync(producer.Image);
            await _dbContext.SaveChangesAsync();

            // assign the new image id to the producer image id foreign key
            producer.ImageId = producer.Image.Id;
            _dbContext.Producer.Entry(producer).State = EntityState.Modified;

            // remove old producer image from database
            _dbContext.Image.Remove(oldImage);
            await _dbContext.SaveChangesAsync();
            return producer;
        }
        public async Task<Producer> AddProducerWithImageUplodaing(Producer producer)
        {
            var imagePath = await _imageUploadService.UploadAsync(producer.Image, nameof(Producer) + producer.FullName!);

            producer.Image.ImagePath = imagePath;
            await _dbContext.Producer.AddAsync(producer);
            await _dbContext.SaveChangesAsync();
            return producer;
        }
        public async Task DeleteAsyncWithImage(Producer producer)
        {
            // remove actor image from server
            _dbContext.Producer.Remove(producer);
            if (producer.Image != null)
            {
                // remova actor's image from server
                _imageUploadService.Delete(producer.Image.ImagePath);
                _dbContext.Image.Remove(producer.Image);
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
