using FoodieStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodieStoreAPI.Repositories
{
  public interface ICustomerRepository
  {
    Task<Customer> GetCustomerAsync(Guid customerId);
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task AddCustomerAsync(Customer customer);
    void UpdateCustomer(Customer customer);
    void RemoveCustomer(Customer customer);
  }
}
