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
    private readonly string _connectionString;
    private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

    public CustomerRepository()
    {
      _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=FoodieStoreCore;Trusted_Connection=True;";
    }
    public async Task AddCustomerAsync(Customer customer)
    {
      using (IDbConnection dbConnection = _connection)
      {
        string query = @"INSERT INTO Customers
                         (Firstname, Lastname, Email, Password, Address, City, PostalCode, Telephone)
                         VALUES(@Firstname, @Lastname, @Email, @Password, @Address, @City, @PostalCode, @Telephone)";

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
        var customers = await dbConnection.QueryAsync<Customer>(query);
        return customers;
      }
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
