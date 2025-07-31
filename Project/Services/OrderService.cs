using Project.Models;
using Project.Repositories.@interface;
using Project.Services.Interface;

namespace Project.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        { 
            return await _repository.GetAllAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        { 
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateOrderAsync(Order order)
        { 
            await _repository.AddAsync(order);
        }

        public async Task UpdateOrderAsync(Order order)
        { 
            await _repository.UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        { 
            await _repository.DeleteAsync(id);
        }

    }
}
