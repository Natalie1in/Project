using Project.Models;

namespace Project.Repositories.@interface
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int id);
        Task<OrderDetail?> GetOrderDetailAsync(int orderId, int productId);
        Task UpdateOrderDetailAsync(OrderDetail detail);
    }
}
