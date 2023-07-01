using mvc.Models;

namespace mvc.Interfaces
{
    public interface ICartService
    {
        Task<Cart?> GetUserCartAsync(int userId, string email);
        Task<Cart?> AddMovieToCartAsync(int movieId, int userId, string email);
        Task<Cart?> RemoveMovieFromCartAsync(int movieId, int userId, string email);
    }
}
