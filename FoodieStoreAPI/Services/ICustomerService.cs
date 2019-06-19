using FoodieStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodieStoreAPI.Services
{
  public interface ICustomerService
  {
    Task<Customer> GetCustomerAsync(Guid customerId);
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task AddCustomerAsync(Customer customer);
    Task UpdateCustomer(Customer customer);
    void RemoveCustomer(Customer customer);
  }
}
