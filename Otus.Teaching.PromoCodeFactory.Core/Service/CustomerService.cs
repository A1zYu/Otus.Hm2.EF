using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;

namespace Otus.Teaching.PromoCodeFactory.Core.Service;

public class CustomerService(IRepository<Customer> customerRepository)
{
    private readonly IRepository<Customer> _customerRepository = customerRepository;

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync() => await _customerRepository.GetAllAsync();
    public async Task<Customer> GetCustomerByIdAsync(Guid id) => await _customerRepository.GetByIdAsync(id);
    public async Task<Customer> AddCustomerAsync(Customer item) => await _customerRepository.AddAsync(item);
    public async Task UpdateCustomer(Customer item) => await _customerRepository.UpdateAsync(item);
    public async Task DeleteCustomer(Customer item) => await _customerRepository.DeleteAsync(item);
}