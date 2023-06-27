namespace mvc.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }

        // Foreign Keys
        public int CartId { get; set; }
        public int MovieId { get; set; }

        // Navigation Properties
        public Movie Movie { get; set; } = new Movie();
        public Cart Cart { get; set; } = new Cart();
    }
}
