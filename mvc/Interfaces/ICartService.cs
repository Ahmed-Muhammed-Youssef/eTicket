using mvc.Models;

namespace mvc.Interfaces
{
    public interface ICartService
    {
        Task<Cart?> GetUserCartAsync(string userId, string email);
        Task<Cart?> AddMovieToCartAsync(int movieId, string userId, string email);
        Task<Cart?> RemoveMovieFromCartAsync(int movieId, string userId, string email);
    }
}
