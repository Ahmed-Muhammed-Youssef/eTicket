using mvc.Data.Base;

namespace mvc.Models
{
    public class Order : IEntityBase
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";

        // Foreign key
        public string UserId { get; set; } = "";
        // Navigation Propertt
        public AppUser AppUser { get; set; } = new AppUser();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem> { };
        // utility method
        public decimal GetTotalPrice()
        {
            return OrderItems.Sum(x => x.Price);
        }
    }
}
