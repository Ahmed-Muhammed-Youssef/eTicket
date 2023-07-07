using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Data.Base;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Services
{
    public class OrderService :  IOrderService
    {
        private readonly AppDbContext _dbContext;

        public OrderService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
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
                    MovieId = item.MovieId,
                    Movie = item.Movie
                });
            }
            var order = new Order
            {
                OrderItems = orderItems,
                Email = cart.Email,
                UserId = cart.UserId,
                AppUser = cart.AppUser
            };
            await _dbContext.Order.AddAsync(order);
            _dbContext.Cart.Remove(cart);

            await _dbContext.SaveChangesAsync();
            return order;
        }
    
        public async Task<List<Order>> GetUserOrdersAsync(string userId, string email)
        {
            var orders = await _dbContext.Order
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Movie)
                .Where(o => o.UserId == userId && o.Email == email)
                .ToListAsync();
            return orders;
        }
    }
}
