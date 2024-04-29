using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TexnomartClone.Application.DTOs.CategoryDTOs;
using TexnomartClone.Application.Interfaces;

namespace TexnomartClone.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpPost]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> Createasync(AddCategoryDto dto)
    {
        await _categoryService.CreateAsync(dto);
        return Ok();
    }

    [HttpGet("id")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        await _categoryService.GetByIdAsync(id);
        return Ok();
    }

    [HttpGet("name")]
    public async Task<IActionResult> GetByNameAsync(string name) 
    {
        return Ok(await _categoryService.GetByNameAsync(name));    
    }

    [HttpGet]
    // in case of copy it is written by Saidjon
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _categoryService.GetAllAsync());
    }

    [HttpPut]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> UpdateAsync([FromBody]CategoryDto dto) 
    {
        await _categoryService.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete("id")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> DeleteByIdAsync(int id) 
    {
        await _categoryService.GetByIdAsync(id);
        return Ok();
    }
}
