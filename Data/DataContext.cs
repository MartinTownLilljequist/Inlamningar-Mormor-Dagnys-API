using eshop.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace eshop.api.Data;

public class DataContext : DbContext
{
  public DbSet<Product> Products { get; set; }
  public DbSet<SalesOrder> SalesOrders { get; set; }
  public DbSet<OrderItem> OrderItems { get; set; }
  public DbSet<Supplier> Suppliers { get; set; }
  public DbSet<SupplierProduct> SupplierProducts { get; set; }
  public DbSet<Customer> Customers { get; set; }
  public DbSet<Address> Addresses { get; set; }
  public DbSet<PostalAddress> PostalAddresses { get; set; }
  public DbSet<AddressType> AddressTypes { get; set; }
  public DbSet<CustomerAddress> CustomerAddresses { get; set; }
  public DbSet<SupplierAddress> SupplierAddresses { get; set; }
  public DataContext(DbContextOptions options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<OrderItem>().HasKey(o => new { o.ProductId, o.SalesOrderId });
    modelBuilder.Entity<SupplierProduct>().HasKey(o => new { o.ProductId, o.SupplierId });
    modelBuilder.Entity<CustomerAddress>().HasKey(c => new { c.AddressId, c.CustomerId });
    modelBuilder.Entity<SupplierAddress>().HasKey(s => new { s.AddressId, s.SupplierId });

    base.OnModelCreating(modelBuilder);
  }
}
