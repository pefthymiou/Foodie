using FoodieStoreAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodieStoreAPI.UnitOfWork
{
  public interface IUnitOfWork : IDisposable
  {
    ICustomerRepository CustomerRepository { get; }
    IProductRepository ProductRepository { get; }

    void Commit();
  }
}
