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
        public async Task<Actor> AddActorWithImageUplodaing(Actor actor)
        {
            var imagePath = await _imageUploadService.UploadAsync(actor.Image, nameof(Actor) + actor.FullName!);
            
            actor.Image.ImagePath = imagePath;
            await _dbContext.Image.AddAsync(actor.Image);
            await _dbContext.SaveChangesAsync();
            
            actor.ImageId = actor.Image.Id;
            await _dbContext.Actor.AddAsync(actor);
            await _dbContext.SaveChangesAsync();
            return actor; 
        }
    }
}
