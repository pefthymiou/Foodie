using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FoodieStoreAPI.Models;

namespace FoodieStoreAPI.Repositories
{
  public class ProductRepository : IProductRepository
  {
    private readonly IDbConnection _connection;

    public ProductRepository(IDbConnection connection)
    {
      _connection = connection;
    }

    public async Task AddProductAsync(Product product)
    {
      using (IDbConnection dbConnection = _connection)
      {
        try
        {
          string query = @"INSERT INTO Products
                          (ProductName, ProductDescription, ProductPrice)
                          VALUES (@ProductName, @ProductDescription, @ProductPrice)";

          await dbConnection.ExecuteAsync(query, product);
        }
        catch (Exception)
        {

          throw;
        }
      }
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
      using (IDbConnection dbConnection = _connection)
      {
        string query = @"SELECT * FROM Products";
        var products = await dbConnection.QueryAsync<Product>(query);
        return products;
      }
    }

    public Task<Customer> GetProductAsync(int productId)
    {
      throw new NotImplementedException();
    }

    public void RemoveProduct(Product product)
    {
      throw new NotImplementedException();
    }

    public void UpdateProduct(Product product)
    {
      throw new NotImplementedException();
    }
  }
}
