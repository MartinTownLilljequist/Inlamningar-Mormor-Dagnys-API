using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eshop.api.ViewModels.Address;
using eshop.api.ViewModels.Supplier;

namespace eshop.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController(IUnitOfWork unitOfWork) : ControllerBase
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  [HttpGet()]
  public async Task<ActionResult> ListAllSuppliers()
  {
    try
    {
      return Ok(new { success = true, data = await _unitOfWork.SupplierRepository.List() });
    }
    catch (Exception ex)
    {
      return NotFound($"Tyvärr hittade vi inget {ex.Message}");
    }

  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetSupplier(int id)
  {
    try
    {
      return Ok(new { success = true, data = await _unitOfWork.SupplierRepository.Find(id) });
    }
    catch (Exception ex)
    {
      return NotFound(new { success = false, message = ex.Message });
    }
  }
}
