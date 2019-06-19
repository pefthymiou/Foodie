using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodieStoreAPI.Models
{
  public class Order
  {
    public int OrderId { get; set; }
    public DateTime DateCreated { get; set; }
    public string OrderState { get; set; }

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }

    public List<OrderDetail> OrderDetails { get; set; }
  }
}
