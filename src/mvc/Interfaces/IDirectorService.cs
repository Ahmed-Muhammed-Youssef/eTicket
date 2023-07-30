using mvc.Data.Base;
using mvc.Models;

namespace mvc.Interfaces
{
    public interface IDirectorService : IEntityBaseRepository<Director>
    {
        public Task<Director> AddDirectorWithImageUplodaing(Director director);
        public Task<Director> UpdateDirectorWithImageAsync(Director director);
        public Task DeleteAsyncWithImage(Director director);
    }
}
