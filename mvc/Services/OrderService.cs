using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Data.Base;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Services
{
    public class OrderService : EntityBaseRepository<Order>, IOrderService
    {
        private readonly AppDbContext _dbContext;

        public OrderService(AppDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
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
            if(cart != null)
            {
                var oldCartItem = cart.CartItems.FirstOrDefault(ci => ci.MovieId == movieId);
                if(oldCartItem != null)
                {
                    oldCartItem.Amount ++;
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

        public async Task<Order> OrderAsync(Cart cart)
        {
            var orderItems = new List<OrderItem>();
            foreach(var item in cart.CartItems)
            {
                orderItems.Add( new OrderItem
                {
                    Amount = item.Amount,
                    Price = item.Price,
                    MovieId = item.MovieId
                });
            }
            var order = new Order
            {
                OrderItems = orderItems,
                Email = cart.Email,
                UserId = cart.UserId
            };
            await _dbContext.Order.AddAsync(order);
            _dbContext.Cart.Remove(cart);

            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Cart?> RemoveMovieFromCartAsync(int movieId, int userId, string email)
        {
            var movie  = await _dbContext.Movie
                .FirstOrDefaultAsync(Movie => Movie.Id == movieId);
            var cart = await _dbContext.Cart
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.Email == email && c.UserId == userId);

            if(movie == null || cart == null)
            {
                return null;
            }
            var cartItem = cart.CartItems.FirstOrDefault(c => c.Id == movieId);
            if(cartItem == null)
            {
                return null;
            }
            cartItem.Amount--;
            if(cartItem.Amount == 0)
            {
                _dbContext.CartItem.Remove(cartItem);
            }
            else
            {
                _dbContext.CartItem.Entry(cartItem).State = EntityState.Modified;  
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
