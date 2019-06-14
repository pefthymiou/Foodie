using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodieStoreAPI.Models;
using FoodieStoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodieStoreAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomersController : ControllerBase
  {
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
      _customerService = customerService;
    }

    [HttpGet("{id}")]
    public async Task<Customer> GetCustomer(Guid customerId)
    {
      return await _customerService.GetCustomerAsync(customerId);
    }

    [HttpGet]
    public async Task<IEnumerable<Customer>> GetCustomers()
    {
      return await _customerService.GetAllCustomersAsync();
    }

    [HttpPost]
    public async Task AddCustomer([FromBody]Customer customer)
    {
      await _customerService.AddCustomerAsync(customer);
    }
  }
}