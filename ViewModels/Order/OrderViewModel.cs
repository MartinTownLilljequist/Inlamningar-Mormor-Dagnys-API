using eshop.api.Entities;
using eshop.api.ViewModels;

namespace eshop.api;

public class OrderViewModel : OrdersViewModel
{
  public int ProductId { get; set; }
  public string ProductName { get; set; }
  public int Quantity { get; set; }
  public decimal ProductPrice { get; set; }
  
  public IList<AddressViewModel> Addresses { get; set; }
}
