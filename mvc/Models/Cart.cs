namespace mvc.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";

        // Foreign Keys
        public int UserId { get; set; }
        
        // Navigation Properties
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

    }
}