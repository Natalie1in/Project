using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Repositories.Interface;
using Project.Services.Interface;

namespace Project.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Customer>> GetAllAsync() 
        {
            return await _repository.GetAllAsync();     
        }

        public async Task<Customer?> GetByIdAsync(string customerId)
        {
            return await _repository.GetByIdAsync(customerId);
        }

        public async Task AddAsync(Customer customer)
        { 
            await _repository.AddAsync(customer);
        }

        public async Task UpdateAsync(Customer customer)
        {
            await _repository.UpdateAsync(customer);
        }

        public async Task DeleteAsync(string customerId)
        {
            await _repository.DeleteAsync(customerId);
        } 
    }
}
