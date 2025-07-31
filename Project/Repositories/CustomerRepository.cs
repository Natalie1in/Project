using Microsoft.EntityFrameworkCore;
using Project.Dtos;
using Project.Models;
using Project.Repositories.Interface;

namespace Project.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly NorthwindContext _context;
        public CustomerRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(string customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CustomerOrdersDto>> GetCustomerOrdersWithProductsAsync(int page, int pageSize)
        {
            return await _context.Customers
                .OrderBy(c => c.CustomerId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new CustomerOrdersDto
                {
                    CustomerId = c.CustomerId,
                    CompanyName = c.CompanyName,
                    Orders = c.Orders.Select(o => new OrderDto
                    {
                        OrderId = o.OrderId,
                        OrderDate = o.OrderDate ?? DateTime.MinValue,
                        Products = o.OrderDetails.Select(od => new OrderProductDto
                        {
                            ProductName = od.Product.ProductName,
                            Quantity = od.Quantity
                        }).ToList()
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<int> GetTotalCustomerCountAsync()
        {
            return await _context.Customers.CountAsync();
        }
    }
}
