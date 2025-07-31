using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Repositories.@interface;

namespace Project.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly NorthwindContext _context;
        public OrderRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<OrderDetail?> GetOrderDetailAsync(int orderId, int productId)
        {
            return await _context.OrderDetails
                .FirstOrDefaultAsync(od => od.OrderId == orderId && od.ProductId == productId);
        }

        public async Task UpdateOrderDetailAsync(OrderDetail detail)
        {
            _context.OrderDetails.Update(detail);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            return await _context.OrderDetails
                .Where(od => od.OrderId == orderId)
                .ToListAsync();
        }

        public async Task RemoveOrderDetailsAsync(IEnumerable<OrderDetail> orderDetails)
        {
            _context.OrderDetails.RemoveRange(orderDetails);
            await _context.SaveChangesAsync();
        }


    }
}
