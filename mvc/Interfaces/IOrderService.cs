using mvc.Models;

namespace mvc.Interfaces
{
    public interface IOrderService 
    {
        
        Task<List<Order>> GetUserOrdersAsync(string userId, string email);
        Task<Order> OrderAsync(Cart cart);
        Task<List<Order>> GetOrdersWithUsersAsync();

    }
}
