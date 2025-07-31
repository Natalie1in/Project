using Microsoft.EntityFrameworkCore;
using Project.Dtos;
using Project.Models;
using Project.Repositories;
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

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var details = await _repository.GetOrderDetailsByOrderIdAsync(id);
            await _repository.RemoveOrderDetailsAsync(details);

            var order = await _repository.GetByIdAsync(id);
            if (order == null)
                return false;

            await _repository.DeleteAsync(order);
            return true;
        }

        public async Task<bool> UpdateProductQuantityAsync(UpdateOrderProductDto model)
        {
            var detail = await _repository.GetOrderDetailAsync(model.OrderId, model.ProductId);
            if (detail == null)
                return false;

            detail.Quantity = model.Quantity;
            await _repository.UpdateOrderDetailAsync(detail);
            return true;
        }
    }
}
