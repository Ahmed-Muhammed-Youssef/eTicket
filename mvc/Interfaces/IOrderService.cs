using mvc.Models;

namespace mvc.Interfaces
{
    public interface IOrderService 
    {
        
        Task<List<Order>> GetUserOrdersAsync(int userId, string email);
        Task<Order> OrderAsync(Cart cart);

    }
}
