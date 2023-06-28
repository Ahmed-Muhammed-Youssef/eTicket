using mvc.Data;
using mvc.Data.Base;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Services
{
    public class CartItemService : EntityBaseRepository<CartItem>, ICartItemService
    {
        public CartItemService(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
