using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FoodieStoreAPI.Models;
using FoodieStoreAPI.Repositories;

namespace FoodieStoreAPI.Services
{
  public class CustomerService : ICustomerService
  {
    private readonly ICustomerRepository _customerRepository;
    public CustomerService(ICustomerRepository customerRepository)
    {
      _customerRepository = customerRepository;
    }
    public async Task AddCustomerAsync(Customer customer)
    {
      Customer cust = new Customer()
      {
        Firstname = customer.Firstname,
        Lastname = customer.Lastname,
        Email = customer.Email,
        Password = customer.Password,
        Address = customer.Address,
        City = customer.City,
        PostalCode = customer.PostalCode,
        Telephone = customer.Telephone
      };
      await _customerRepository.AddCustomerAsync(cust);
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
      IEnumerable<Customer> customers = await _customerRepository.GetAllCustomersAsync();
      return customers;
    }

    public async Task<Customer> GetCustomerAsync(Guid customerId)
    {
      var customer = await _customerRepository.GetCustomerAsync(customerId);
      return customer;
    }

    public void RemoveCustomer(Customer customer)
    {
      throw new NotImplementedException();
    }

    public void UpdateCustomer(Customer customer)
    {
      throw new NotImplementedException();
    }
  }
}
