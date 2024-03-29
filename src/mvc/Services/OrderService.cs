﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<Order> OrderAsync(Cart cart, string transactionKey)
        {
            var orderItems = new List<OrderItem>();
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == cart.UserId);
            if(user == null)
            {
                return new Order();
            }
            foreach (var item in cart.CartItems)
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
                TransactionKey = transactionKey,
                UserId = cart.UserId,
                AppUser = user
            };
            await _dbContext.Orders.AddAsync(order);
            _dbContext.Carts.Remove(cart);

            await _dbContext.SaveChangesAsync();
            return order;
        }
    
        public async Task<List<Order>> GetUserOrdersAsync(string userId, string email)
        {
            var orders = await _dbContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Movie)
                .Where(o => o.UserId == userId && o.Email == email)
                .ToListAsync();
            return orders;
        }
        public async Task<List<Order>> GetOrdersWithUsersAsync()
        {
            var orders = await _dbContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Movie)
                .Include(o => o.AppUser)
                .ToListAsync();
            return orders;
        }
    
        public async Task MarkAsDone(int id)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            if (order is null)
            {
                throw new InvalidOperationException("order not found");
            }
            if (order.OrderStatus == Data.Enums.OrderStatus.Done)
            {
                throw new InvalidOperationException("order is already done");
            }
            order.OrderStatus = Data.Enums.OrderStatus.Done;

            await _dbContext.SaveChangesAsync();
        }
    }
}
