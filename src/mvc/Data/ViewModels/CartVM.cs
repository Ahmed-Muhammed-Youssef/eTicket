using mvc.Models;

namespace mvc.Data.ViewModels
{
    public class CartVM
    {
        public required Cart Cart { get; set; }
        public decimal Total { get; set; }
    }
}
