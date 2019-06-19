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
  public class ProductsController : ControllerBase
  {
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
      _productService = productService;
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> GetProducts()
    {
      return await _productService.GetAllProductsAsync();
    }

    [HttpPost]
    public async Task AddProduct([FromBody]Product product)
    {
      await _productService.AddProductAsync(product);
    }
  }
}