using mvc.Data.Base;
using mvc.Models;

namespace mvc.Interfaces
{
    public interface IOrderService : IEntityBaseRepository<Order>
    {
        Task<Cart?> GetUserCartAsync(int userId, string email);
        Task<Cart?> AddMovieToCartAsync(int movieId, int userId, string email);
        Task<Cart?> RemoveMovieFromCartAsync(int movieId, int userId, string email);
        Task<Order> OrderAsync(Cart cart);

    }
}
