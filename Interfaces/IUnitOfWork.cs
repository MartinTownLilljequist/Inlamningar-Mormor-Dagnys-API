namespace eshop.api;

public interface IUnitOfWork
{
  ICustomerRepository CustomerRepository { get; }
  ISupplierRepository SupplierRepository { get; }
  IAddressRepository AddressRepository { get; }
  IOrderRepository OrderRepository { get; }

  Task<bool> Complete();
  bool HasChanges();
}
