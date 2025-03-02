using System.ComponentModel.DataAnnotations;

namespace eshop.api.Entities;

public class SalesOrder
{
  [Key]
  public int SalesOrderId { get; set; }
  public int CustomerId { get; set; }
  public int ProductId { get; set; }
  public DateTime OrderDate { get; set; }
  public Customer Customer { get; set; }

  // Navigational property...
  public IList<OrderItem> OrderItems { get; set; }
}
