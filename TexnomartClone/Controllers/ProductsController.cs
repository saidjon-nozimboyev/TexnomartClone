using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TexnomartClone.Application.DTOs.ProductDTOs;
using TexnomartClone.Application.Interfaces;

namespace TexnomartClone.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpPost]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> CreateAsync([FromForm] AddProductDto dto)
    {
        await _productService.CreateAsync(dto);
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> UpdateAsync(ProductDto dto) 
    {
        await _productService.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete("id")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> DeleteAsync(int id) 
    {
        await _productService.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("id")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _productService.GetByIdAsync(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _productService.GetAllAsync());
    }
    /*Task CreateAsync(AddProductDto dto);
    Task UpdateAsync(ProductDto dto);
    Task DeleteAsync(int id);
    Task<ProductDto?> GetByIdAsync(int id);
    Tillatev has copied
    Task<IEnumerable<ProductDto>> GetAllAsync();*/

}
