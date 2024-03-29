﻿using Microsoft.EntityFrameworkCore;
using mvc.Data;
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
        public async Task<Cart?> AddMovieToCartAsync(int movieId, string userId, string email)
        {
            var cartTask = _dbContext.Carts
                .Where(c => c.UserId == userId && c.Email == email)
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync();

            var user = _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            var movie = _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

            await Task.WhenAll(cartTask, user, movie);

            var cart = cartTask.Result;

            if(user.Result == null)
            {
                return null;
            }

            if (movie.Result == null)
            {
                return cart;
            }
            var cartItem = new CartItem()
            {
                MovieId = movieId,
                Amount = 1,
                Price = movie.Result.Price,
                Movie = movie.Result
            };
            if (cart != null)
            {
                var oldCartItem = cart.CartItems.FirstOrDefault(ci => ci.MovieId == movieId);
                if (oldCartItem != null)
                {
                    oldCartItem.Amount++;
                    oldCartItem.Price += movie.Result.Price;
                }
                else
                {
                    cart.CartItems.Add(cartItem);
                }
                _dbContext.Carts.Entry(cart).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return cartTask.Result;
            }
            // if the user didn't create any carts before.
            cart = new Cart
            {
                CartItems = new List<CartItem> { cartItem },
                UserId = userId,
                Email = email,
                AppUser = user.Result
            };
            cartItem.Cart = cart;
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();
            return cart;
        }
        public async Task<Cart?> RemoveMovieFromCartAsync(int movieId, string userId, string email)
        {
            var cart = await _dbContext.Carts
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
                _dbContext.CartItems.Remove(cartItem);
            }
            else
            {
                cartItem!.Amount--;
                _dbContext.Carts.Entry(cart).State = EntityState.Modified;
            }
            await _dbContext.SaveChangesAsync();
            return cart;
        }
        public async Task<Cart?> GetUserCartAsync(string userId, string email)
        {
            var cart = await _dbContext.Carts
               .Where(c => c.UserId == userId && c.Email == email)
               .Include(c => c.CartItems)
               .ThenInclude(ci => ci.Movie)
               .FirstOrDefaultAsync();
            return cart;
        }
    }
}
