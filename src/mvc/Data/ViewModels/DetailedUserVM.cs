using mvc.Models;

namespace mvc.Data.ViewModels
{
    public class DetailedUserVM : UserVM
    {
        public List<Order> Orders { get; set; } = new List<Order>();
        public Cart? Cart { get; set; }
        public decimal MoneyPaied { get; set; }
    }
}
