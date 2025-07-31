using Project.Dtos;
using Project.Models;

namespace Project.Services.Interface
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int id);
        Task<bool> UpdateProductQuantityAsync(UpdateOrderProductDto model);
    }
}
