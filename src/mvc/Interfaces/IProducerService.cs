using mvc.Data.Base;
using mvc.Models;

namespace mvc.Interfaces
{
    public interface IProducerService : IEntityBaseRepository<Producer>
    {
        public Task<Producer> AddProducerWithImageUplodaing(Producer producer);
        public Task<Producer> UpdateProducerWithImageAsync(Producer producer);
    }
}
