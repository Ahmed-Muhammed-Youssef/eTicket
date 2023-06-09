﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvc.Data.Configurations;
using mvc.Models;

namespace mvc.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<ActorMovie> ActorMovie { get; set; }
        public DbSet<Producer> Producer { get; set; }
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActorConfiguirations());
            modelBuilder.ApplyConfiguration(new ActorsMoviesConfigurations());
            modelBuilder.ApplyConfiguration(new MovieConfigurations());
            modelBuilder.ApplyConfiguration(new CinemaConfigurations());
            modelBuilder.ApplyConfiguration(new ProducerConfigurations());
            modelBuilder.ApplyConfiguration(new OrderConfigurations());
            modelBuilder.ApplyConfiguration(new OrderItemConfigurations());
            modelBuilder.ApplyConfiguration(new CartConfigurations());
            modelBuilder.ApplyConfiguration(new CartItemConfigurations());
            base.OnModelCreating(modelBuilder);
        }
    }
}
