using System.ComponentModel.DataAnnotations.Schema;

namespace eshop.api.Entities;

public class SupplierProduct
{
  public int SupplierId { get; set; }
  public int ProductId { get; set; }
  public string ProductName { get; set; }
  public double Price { get; set; }

  // Navigational properties...
  public Product Product { get; set; }
  public Supplier Supplier { get; set; }
}
