using mvc.Data.Base;

namespace mvc.Models
{
    public class Cart : IEntityBase
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";

        // Foreign Keys
        public string UserId { get; set; } = "";

        // Navigation Properties
        public AppUser AppUser { get; set; } = new AppUser();
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();


        // utility method
        public decimal GetTotalPrice()
        {
            return CartItems.Sum(x => x.Price);
        }

    }
}