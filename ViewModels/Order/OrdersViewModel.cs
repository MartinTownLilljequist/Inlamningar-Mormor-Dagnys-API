using eshop.api.Entities;
using eshop.api.ViewModels;

namespace eshop.api;

public class OrdersViewModel
{
  public int Id { get; set; }
  public int CustomerId { get; set; }
  public int SalesOrderId { get; set; }
  public CustomerViewModel Customer { get; set; }
  public DateTime OrderDate { get; set; }
  public IList<OrderItem> OrderItems { get; set; }
  public decimal TotalPrice { get; set; }
  public IList<ProductGetViewModel> Products { get; set; }
  
}
