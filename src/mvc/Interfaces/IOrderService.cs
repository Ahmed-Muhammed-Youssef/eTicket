using mvc.Models;

namespace mvc.Interfaces
{
    public interface IOrderService 
    {
        
        Task<List<Order>> GetUserOrdersAsync(string userId, string email);
        Task<Order> OrderAsync(Cart cart, string transactionKey);
        Task<List<Order>> GetOrdersWithUsersAsync();
        public Task MarkAsDone(int id);

    }
}
