using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodieStoreAPI.Models;
using FoodieStoreAPI.Repositories;

namespace FoodieStoreAPI.Services
{
  public class ProductService : IProductService
  {
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }
    public async Task AddProductAsync(Product product)
    {
      Product prod = new Product()
      {
        ProductName = product.ProductName,
        ProductDescription = product.ProductDescription,
        ProductPrice = product.ProductPrice
      };

      await _productRepository.AddProductAsync(prod);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
      IEnumerable<Product> products = await _productRepository.GetAllProductsAsync();
      return products;
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
