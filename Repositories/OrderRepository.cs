
using System.Security.Cryptography;
using eshop.api.Data;
using eshop.api.Entities;
using eshop.api.ViewModels;
using eshop.api.ViewModels.Address;
using eshop.api.ViewModels.Order;
using eshop.api.ViewModels.Supplier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eshop.api;

public class OrderRepository(DataContext context, IAddressRepository repo) : IOrderRepository
{
  private readonly DataContext _context = context;
  private readonly IAddressRepository _repo = repo;

    

public async Task<bool> Add(OrderPostViewModel model)
{
    try
    {
        var customer = await _context.Customers.FindAsync(model.CustomerId);
        if (customer == null)
        {
            throw new EShopException("Angivet kund-ID finns inte.");
        }

        // Create a new SalesOrder
        var newOrder = new SalesOrder
        {
            CustomerId = model.CustomerId,
            OrderDate = model.OrderDate,
            OrderItems = new List<OrderItem>()
        };

        var addedProductIDs = new HashSet<int>();

        foreach (var product in model.Products)
        {
            if (addedProductIDs.Contains(product.ProductId))
            {
                throw new EShopException($"Produkt-ID {product.ProductId} har angivits mer än en gång.");
            }

            var prod = await _context.Products.SingleOrDefaultAsync(p => p.Id == product.ProductId);
            if (prod == null)
            {
                throw new EShopException($"Du har angivet ett produkt-ID ({product.ProductId}) som inte existerar");
            }

            var item = new OrderItem
            {
                ProductId = product.ProductId,
                Quantity = product.Quantity,
                SalesOrderId = newOrder.SalesOrderId,
                ProductPrice = prod.Price
            };

            // Add the order item to the SalesOrder's list
            newOrder.OrderItems.Add(item);

            // Mark product ID as added
            addedProductIDs.Add(product.ProductId);
        }

        // Add the order once, outside the loop
        await _context.SalesOrders.AddAsync(newOrder);
        await _context.SaveChangesAsync();

        return true;
    }
    catch (EShopException)
    {
        throw; // No need to wrap in another exception
    }
    catch (Exception ex)
    {
        throw new Exception(ex.Message); // Generic exception handling
    }
}

    // public async Task<IList<OrdersViewModel>> List()
    // {
    //     try
    // {
    //   var orders = await _context.SalesOrders
    //     .Include(o => o.OrderItems)
    //     .ThenInclude(oi => oi.Product)
    //     .Include(c => c.Customer)
    //     .ToListAsync();

    //   IList<OrdersViewModel> response = [];

    //   foreach (var order in orders)
    //   {
    //     var view = new OrdersViewModel
    //     {
    //       OrderDate = order.OrderDate,
    //             Id = order.SalesOrderId,
    //             Customer = new CustomerViewModel
    //             {
    //                 Id = order.Customer.Id,
    //                 FirstName = order.Customer.FirstName,
    //                 LastName = order.Customer.LastName,
    //             },
    //             OrderItems = new OrderViewModel
    //             {
    //                 OrderDate = order.OrderDate,
    //                 Id = order.SalesOrderId,
    //             }
    //             .ToListAsync(),
    //             TotalPrice = order.OrderItems.Sum(oi => oi.ProductPrice * oi.Quantity)
    //         };

    //     response.Add(view);
    //   }

    //   return response;
    // }
    // catch (Exception ex)
    // {
    //   throw new Exception($"Ett fel inträffade i ListAllSupplier(SupplierRepository) {ex.Message}");
    // }
    
    
    // }

    

    public async Task<OrderViewModel> Find(int id)
{
    var order = await _context.SalesOrders
        .Include(o => o.Customer) 
        .Include(o => o.OrderItems) 
        .ThenInclude(oi => oi.Product) 
        .FirstOrDefaultAsync(o => o.ProductId == id);

    if (order == null)
    {
        return null; 
    }

    return new OrderViewModel
    {
        CustomerId = order.CustomerId,
        SalesOrderId = order.SalesOrderId,
        Customer = new CustomerViewModel
        {
            Id = order.Customer.Id,
            FirstName = order.Customer.FirstName,
            LastName = order.Customer.LastName,
            Email = order.Customer.Email
        },
        OrderDate = order.OrderDate,
        TotalPrice = (decimal)order.OrderItems.Sum(oi => oi.ProductPrice * oi.Quantity),
        Products = order.OrderItems.Select(oi => new ProductGetViewModel
        {
            ProductId = oi.ProductId,
            ProductName = oi.Product.ProductName,
            Price = (decimal)oi.ProductPrice,
            Quantity = oi.Quantity
        }).ToList()
    };
}


    public async Task<IList<OrdersViewModel>> List()
{
    try
    {
        var orders = await _context.SalesOrders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Include(o => o.Customer)
            .ToListAsync();

        IList<OrdersViewModel> response = new List<OrdersViewModel>();

        foreach (var order in orders)
        {
            var view = new OrdersViewModel
            {
                SalesOrderId = order.SalesOrderId,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                TotalPrice = order.OrderItems.Sum(oi => (decimal)oi.ProductPrice * oi.Quantity),
                Products = order.OrderItems.Select(oi => new ProductGetViewModel
                {
                    ProductId = oi.ProductId,
                    ProductName = oi.Product.ProductName,
                    Quantity = oi.Quantity,
                    Price = (decimal)oi.ProductPrice
                }).ToList()
            };

            response.Add(view);
        }

        return response;
    }
    catch (Exception ex)
    {
        throw new Exception($"Ett fel inträffade i ListAllSupplier(SupplierRepository) {ex.Message}");
    }
}

}

