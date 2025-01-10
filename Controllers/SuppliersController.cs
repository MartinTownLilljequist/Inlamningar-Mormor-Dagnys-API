using eshop.api.Data;
using eshop.api.Entities;
using eshop.api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eshop.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController(DataContext context) : ControllerBase
{
  private readonly DataContext _context = context;

  [HttpGet()]
  public async Task<ActionResult> ListAllSuppliers()
  {
    // DEKLARATIV PROGRAMMERING❗️
    // När vi hämtar alla SalesOrder objekt
    // ta med dig alla SupplierProducts objekt också
    var suppliers = await _context.Suppliers
      .Include(c => c.SupplierProducts) // Vi måste nu projicera datat till det format som vi vill leverera tillbaka...
      .Select(supplier => new
      {
        supplier.SupplierId,
        supplier.SupplierName,
        supplier.SupplierAddress,
        supplier.SupplierContact,
        supplier.SupplierEmail,
        supplier.SupplierPhone,
        SupplierProducts = supplier.SupplierProducts // Nu måste projicera vad vi vill/behöver ifrån SupplierProducts!!!
          .Select(item => new
          {
            item.Product.ProductName,
            item.Price,
            item.Product.Description
          })
      })
      .ToListAsync();


    return Ok(new { success = true, statusCode = 200, data = suppliers });
  }

  // Hämta ut all information om en specifik beställning baserat orderns id...
  [HttpGet("{id}")]
  public async Task<ActionResult> FindSupplier(int id)
  {
    var supplier = await _context.Suppliers
      .Where(o => o.SupplierId == id)
      .Include(c => c.SupplierProducts)
      .Select(supplier => new
      {
        supplier.SupplierId,
        supplier.SupplierName,
        SupplierProducts = supplier.SupplierProducts
          .Select(item => new
          {
            item.Product.ProductName,
            item.Price,
            item.Product.Description
          })
      })
      .SingleOrDefaultAsync();

    if (supplier is null)
    {
      return NotFound(new { success = false, statusCode = 404, message = $"Tyvärr vi kunde inte hitta någon leverantör med leverantörnummer: {id}" });
    }
    return Ok(new { success = true, statusCode = 200, data = supplier });
  }
}
