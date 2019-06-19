using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FoodieStoreAPI.Repositories;

namespace FoodieStoreAPI.UnitOfWork
{
  public class UnitOfWork
  {
    private IDbConnection _connection;
    private IDbTransaction _transaction;
    private ICustomerRepository _customerRepository;
    private IProductRepository _productRepository;
    private bool _disposed;

    public UnitOfWork(IDbConnection connection)
    {
      _connection = connection;
      _connection.Open();
      _transaction = _connection.BeginTransaction();
    }

    public void Commit()
    {
      try
      {
        _transaction.Commit();
      }
      catch
      {
        _transaction.Rollback();
        throw;
      }
      finally
      {
        _transaction.Dispose();
        _transaction = _connection.BeginTransaction();
        ResetRepositories();
      }
    }

    public void Dispose()
    {
      ToDispose(true);
      GC.SuppressFinalize(this);
    }

    private void ResetRepositories()
    {
      _customerRepository = null;
      _productRepository = null;
    }

    private void ToDispose(bool disposing)
    {
      if (!_disposed)
      {
        if (disposing)
        {
          if (_transaction != null)
          {
            _transaction.Dispose();
            _transaction = null;
          }
          if (_connection != null)
          {
            _connection.Dispose();
            _connection = null;
          }
        }
        _disposed = true;
      }
    }

    ~UnitOfWork()
    {
      ToDispose(false);
    }
  }
}
