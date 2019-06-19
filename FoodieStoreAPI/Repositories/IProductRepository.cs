using FoodieStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodieStoreAPI.Repositories
{
  public interface IProductRepository
  {
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Customer> GetProductAsync(int productId);
    Task AddProductAsync(Product product);
    void UpdateProduct(Product product);
    void RemoveProduct(Product product);
  }
}
