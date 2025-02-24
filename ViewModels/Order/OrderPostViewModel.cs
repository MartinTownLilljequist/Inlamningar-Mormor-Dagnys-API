using eshop.api.ViewModels.Address;

namespace eshop.api.ViewModels.Order;

public class OrderPostViewModel
{
  public string Name { get; set; }
  public string Email { get; set; }
  public string Phone { get; set; }
  public int CustomerId { get; set; }
  public DateTime OrderDate { get; set; }
  public IList<AddressPostViewModel> Addresses { get; set; }
  public IList<ProductGetViewModel> Products { get; set; }

}
