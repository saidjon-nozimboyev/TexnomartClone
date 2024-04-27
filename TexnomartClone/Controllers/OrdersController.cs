using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TexnomartClone.Application.DTOs.OrderDTOs;
using TexnomartClone.Application.Interfaces;

namespace TexnomartClone.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController(IOrderService orderService) : ControllerBase
{
    private readonly IOrderService _orderService = orderService;
    /*
     Task CreateAsync(AddOrderDto dto);
    Task DeleteAsync(int id);
    Task<OrderDto?> GetByIdAsync(int id);
    Task<IEnumerable<OrderDto>> GetAllAsync();
   */
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAsync([FromForm] AddOrderDto dto)
    {
        await _orderService.CreateAsync(dto);
        return Ok();
    }

    [HttpDelete]
    [Authorize (Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _orderService.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("id")]
    [Authorize (Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> GetByIdAsync(int id) 
    {
        return Ok(await _orderService.GetByIdAsync(id));
    }

    [HttpGet]
    [Authorize (Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _orderService.GetAllAsync());
    }
}