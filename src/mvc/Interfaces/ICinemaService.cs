using mvc.Data.Base;
using mvc.Models;

namespace mvc.Interfaces
{
    public interface ICinemaService : IEntityBaseRepository<Cinema> 
    {
        public Task<Cinema> UpdateWithImageAsync(Cinema cinema);
        public Task<Cinema> AddWithImageUplodaing(Cinema cinema);
        public Task DeleteAsyncWithImage(Cinema cinema);
    }
}
