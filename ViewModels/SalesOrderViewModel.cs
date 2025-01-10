namespace eshop.api.ViewModels;

// Syftet är att använda denna klass för POST...
public class SalesOrderViewModel
{
  public string SupplierName { get; set; }
  public IList<ProductGetViewModel> Products { get; set; }
}
