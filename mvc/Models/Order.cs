using mvc.Data.Base;

namespace mvc.Models
{
    public class Order : IEntityBase
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";

        // Foreign key
        public int UserId { get; set; }
        // Navigation Propertt
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem> { };
        // utility method
        public decimal GetTotalPrice()
        {
            return OrderItems.Sum(x => x.Price);
        }
    }
}
