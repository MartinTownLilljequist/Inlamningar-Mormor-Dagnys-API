using eshop.api.Data;
using eshop.api.Entities;
using eshop.api.ViewModels;
using eshop.api.ViewModels.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eshop.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(IUnitOfWork unitOfWork) : ControllerBase
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  [HttpGet()]
  public async Task<ActionResult> ListAllOrders()
  {
    try
    {
      return Ok(new { success = true, data = await _unitOfWork.OrderRepository.List() });
    }
    catch (Exception ex)
    {
      return NotFound($"Tyvärr hittade vi inget {ex.Message}");
    }

  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetOrder(int id)
  {
    try
    {
      return Ok(new { success = true, data = await _unitOfWork.OrderRepository.Find(id) });
    }
    catch (Exception ex)
    {
      return NotFound(new { success = false, message = ex.Message });
    }
  }

  [HttpPost()]
  public async Task<ActionResult> AddOrder([FromBody]OrderPostViewModel model)
  {
    try
    {
      var result = await _unitOfWork.OrderRepository.Add(model);
      if (result)
      {
        if (await _unitOfWork.Complete())
        {
          return StatusCode(201);
        }
        else
        {
          return StatusCode(500);
        }
      }
      else
      {
        return BadRequest();
      }
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }

  }
}
