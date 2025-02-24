namespace eshop.api.ViewModels;

// Syftet är att använda denna klass för POST...
public class SalesOrderViewModel
{
  public int CustomerId { get; set; }
  public DateTime OrderDate { get; set; }
  public IList<ProductGetViewModel> Products { get; set; }
}
