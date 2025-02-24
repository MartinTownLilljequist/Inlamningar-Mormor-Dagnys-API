namespace eshop.api.Entities;

public class Supplier
{
  public int SupplierId { get; set; }
  public string SupplierName { get; set; }
  public string SupplierContact { get; set; }
  public string SupplierPhone { get; set; }
  public string SupplierEmail { get; set; }
  public IList<SupplierProduct> SupplierProducts { get; set; }
  public IList<SupplierAddress> SupplierAddresses {get; set;}
}
