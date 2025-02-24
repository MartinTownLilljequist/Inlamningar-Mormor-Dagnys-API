namespace eshop.api.Entities;

public class Product
{
  public int Id { get; set; }
  public string ItemNumber { get; set; }
  public string ProductName { get; set; }
  public double Price { get; set; }
  public string Weight { get; set; }
  public string Amount { get; set; }
  public DateTime BestBeforeDate { get; set; }
  public DateTime ManufactureDate { get; set; }
  public string Description { get; set; }
  public string Image { get; set; }

  // Navigational property...
  public IList<SupplierProduct> SupplierProducts { get; set; }
}
