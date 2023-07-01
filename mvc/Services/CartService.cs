using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Data.Base;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Services
{
    public class CartService : ICartService
    {
        private readonly AppDbContext _dbContext;

        public CartService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Cart?> AddMovieToCartAsync(int movieId, int userId, string email)
        {
            var cart = await _dbContext.Cart
                .Where(c => c.UserId == userId && c.Email == email)
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync();
            var movie = await _dbContext.Movie.FirstOrDefaultAsync(m => m.Id == movieId);
            if (movie == null)
            {
                return cart;
            }
            var cartItem = new CartItem()
            {
                MovieId = movieId,
                Amount = 1,
                Price = movie.Price,
                Movie = movie
            };
            if (cart != null)
            {
                var oldCartItem = cart.CartItems.FirstOrDefault(ci => ci.MovieId == movieId);
                if (oldCartItem != null)
                {
                    oldCartItem.Amount++;
                    oldCartItem.Price += movie.Price;
                }
                else
                {
                    cart.CartItems.Add(cartItem);
                }
                _dbContext.Cart.Entry(cart).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return cart;
            }
            // if the user didn't create any carts before.
            cart = new Cart
            {
                CartItems = new List<CartItem> { cartItem },
                UserId = userId,
                Email = email
            };
            cartItem.Cart = cart;
            await _dbContext.Cart.AddAsync(cart);
            await _dbContext.SaveChangesAsync();
            return cart;
        }
        public async Task<Cart?> RemoveMovieFromCartAsync(int movieId, int userId, string email)
        {
            var cart = await _dbContext.Cart
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Movie)
                .FirstOrDefaultAsync(c => c.Email == email && c.UserId == userId);
            var movie = cart!.CartItems.FirstOrDefault(ci => ci.Movie.Id == movieId);

            if (movie == null || cart == null)
            {
                return null;
            }
            var cartItem = cart.CartItems.FirstOrDefault(c => c.MovieId == movieId);

            if (cartItem!.Amount == 1)
            {
                _dbContext.CartItem.Remove(cartItem);
            }
            else
            {
                cartItem!.Amount--;
                _dbContext.Cart.Entry(cart).State = EntityState.Modified;
            }
            await _dbContext.SaveChangesAsync();
            return cart;
        }
        public async Task<Cart?> GetUserCartAsync(int userId, string email)
        {
            var cart = await _dbContext.Cart
               .Where(c => c.UserId == userId && c.Email == email)
               .Include(c => c.CartItems)
               .ThenInclude(ci => ci.Movie)
               .FirstOrDefaultAsync();
            return cart;
        }
    }
}
