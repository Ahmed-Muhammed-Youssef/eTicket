using mvc.Data.Base;
using mvc.Models;

namespace mvc.Interfaces
{
    public interface IDirectorService : IEntityBaseRepository<Director>
    {
        public Task<Director> AddProducerWithImageUplodaing(Director director);
        public Task<Director> UpdateProducerWithImageAsync(Director director);
        public Task DeleteAsyncWithImage(Director director);
    }
}
