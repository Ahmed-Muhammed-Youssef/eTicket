using mvc.Data;
using mvc.Data.Base;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Services
{
    public class CartService : EntityBaseRepository<Cart>, ICartService
    {
        public CartService(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
