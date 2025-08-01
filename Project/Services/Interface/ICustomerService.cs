﻿using Project.Dtos;
using Project.Models;

namespace Project.Services.Interface
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(string customerId);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(string customerId);
        Task<List<CustomerOrdersDto>> GetCustomerOrdersWithProductsAsync(int page, int pageSize);
        Task<int> GetTotalCustomerCountAsync();
    }
}
