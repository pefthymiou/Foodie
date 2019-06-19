using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FoodieStoreAPI.Models;

namespace FoodieStoreAPI.Repositories
{
  public class CustomerRepository : ICustomerRepository
  {
    private readonly IDbConnection _connection;

    public CustomerRepository(IDbConnection connection)
    {
      _connection = connection;
    }

    public async Task AddCustomerAsync(Customer customer)
    {
      using (IDbConnection dbConnection = _connection)
      {
        string query = @"INSERT INTO Customers
                         (CustomerId, Firstname, Lastname, Email, Password, Address, City, PostalCode, Telephone)
                         VALUES(@CustomerId ,@Firstname, @Lastname, @Email, @Password, @Address, @City, @PostalCode, @Telephone)";

        await dbConnection.ExecuteAsync(query, customer);
      }
    }

    public async Task<Customer> GetCustomerAsync(Guid customerId)
    {
      using (IDbConnection dbConnection = _connection)
      {
        string query = @"SELECT * FROM Customers WHERE CustomerId = @customerId";
        var customer = await dbConnection.QueryFirstOrDefaultAsync<Customer>(query, new { @CustomerId = customerId });

        return customer;
      }
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
      using (IDbConnection dbConnection = _connection)
      {
        string query = @"SELECT * FROM Customers";
        var customers = await _connection.QueryAsync<Customer>(query);
        return customers;
      }
    }

    public void RemoveCustomer(Customer customer)
    {
      throw new NotImplementedException();
    }

    public async Task UpdateCustomer(Customer customer)
    {
      using (IDbConnection dbConnection = _connection)
      {
        string query = @"UPDATE Customers
                      SET Address=@Address, City=@City, PostalCode=@PostalCode, Telephone=@Telephone
                      WHERE CustomerId=";

        await dbConnection.ExecuteAsync(query, customer);
      }
    }
  }
}
