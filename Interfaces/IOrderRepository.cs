using eshop.api.ViewModels.Order;

namespace eshop.api;

public interface IOrderRepository
{
    public Task<IList<OrdersViewModel>> List();
    public Task<OrderViewModel> Find(int id);
    public Task<bool> Add(OrderPostViewModel model); 
}
