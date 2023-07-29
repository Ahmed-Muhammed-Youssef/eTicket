using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Data.Base;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Services
{
    public class ActorService : EntityBaseRepository<Actor>, IActorService
    {
        private readonly AppDbContext _dbContext;
        private readonly IImageUploadService _imageUploadService;

        public ActorService(AppDbContext dbContext, IImageUploadService imageUploadService) : base(dbContext)
        {
            _dbContext = dbContext;
            _imageUploadService = imageUploadService;
        }
        public async Task<Actor> UpdateActorWithImageAsync(Actor actor)
        {
            var oldImage = await _dbContext.Actor.Include(a => a.Image)
                .Where(i => i.Id == actor.Id)
                .Select(a => a.Image)
                .FirstOrDefaultAsync();
            if(oldImage == null)
            {
                throw new InvalidOperationException("invalid actor id");
            }
            if(actor.Image.ImageFile == null)
            {
                // without image
                actor.ImageId = oldImage.Id;
                await UpdateAsync(actor);
                return actor;

            }
            // remove old actor image from server
            _imageUploadService.Delete(oldImage.ImagePath);

            // add the new image to server
            var imagePath = await _imageUploadService.UploadAsync(actor.Image, nameof(Actor) + actor.FullName!);
            // add the new image path to the actor
            actor.Image.ImagePath = imagePath;
            

            // add the new image to the database
            await _dbContext.Image.AddAsync(actor.Image);
            await _dbContext.SaveChangesAsync(); 

            // assign the new image id to the actor image id foreign key
            actor.ImageId = actor.Image.Id;
            _dbContext.Actor.Entry(actor).State = EntityState.Modified;

            // remove old actor image from database
            _dbContext.Image.Remove(oldImage);
            await _dbContext.SaveChangesAsync();
            return actor;
        }
        public async Task<Actor> AddActorWithImageUplodaing(Actor actor)
        {
            var imagePath = await _imageUploadService.UploadAsync(actor.Image, nameof(Actor) + actor.FullName!);
            
            actor.Image.ImagePath = imagePath;
            await _dbContext.Actor.AddAsync(actor);
            await _dbContext.SaveChangesAsync();
            return actor; 
        }

    }
}
