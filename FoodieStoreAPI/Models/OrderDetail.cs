using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodieStoreAPI.Models
{
  public class OrderDetail
  {
    public int DetailId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }
  }
}
