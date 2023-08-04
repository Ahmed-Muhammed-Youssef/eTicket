using mvc.Data.Base;
using mvc.Data.Enums;

namespace mvc.Models
{
    public class Order : IEntityBase
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";
        public string TransactionKey { get; set; } = "";
        public OrderStatus OrderStatus { get; set; } = OrderStatus.OnGoing;

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
        public string GetOrderStatusAsString()
        {
            if(OrderStatus == OrderStatus.OnGoing)
            {
                return "On Going";
            }
            else
            {
                return "Done";
            }
        }
    }
}
