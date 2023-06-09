﻿using mvc.Data.Base;

namespace mvc.Models
{
    public class OrderItem : IEntityBase
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        // Foreign Keys
        public int MovieId { get; set; }
        public int OrderId { get; set; }

        // Navigation Properties
        public Movie Movie { get; set; } = new Movie();
        public Order Order { get; set; } = new Order();
    }
}
