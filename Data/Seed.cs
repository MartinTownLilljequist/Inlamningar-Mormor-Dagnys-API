using System.Text.Json;
using eshop.api.Entities;

namespace eshop.api.Data;

public static class Seed
{
  public static async Task LoadProducts(DataContext context)
  {
    var options = new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    };

    if (context.Products.Any()) return;

    var json = File.ReadAllText("Data/json/products.json");
    var products = JsonSerializer.Deserialize<List<Product>>(json, options);

    if (products is not null && products.Count > 0)
    {
      await context.Products.AddRangeAsync(products);
      await context.SaveChangesAsync();
    }
  }

  public static async Task LoadSuppliers(DataContext context)
  {
    var options = new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    };

    if (context.Suppliers.Any()) return;

    var json = File.ReadAllText("Data/json/suppliers.json");
    var orders = JsonSerializer.Deserialize<List<Supplier>>(json, options);

    if (orders is not null && orders.Count > 0)
    {
      await context.Suppliers.AddRangeAsync(orders);
      await context.SaveChangesAsync();
    }
  }

  public static async Task LoadSupplierProducts(DataContext context)
  {
    var options = new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    };

    if (context.SupplierProducts.Any()) return;

    var json = File.ReadAllText("Data/json/supplierproducts.json");
    var supplierproducts = JsonSerializer.Deserialize<List<SupplierProduct>>(json, options);

    if (supplierproducts is not null && supplierproducts.Count > 0)
    {
      await context.SupplierProducts.AddRangeAsync(supplierproducts);
      await context.SaveChangesAsync();
    }
  }
}
