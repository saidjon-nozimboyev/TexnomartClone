using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TexnomartClone.Application.DTOs.UserDTOs;
using TexnomartClone.Application.Interfaces;

namespace TexnomartClone.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        return Ok(await _userService.GetByIdAsync(id));
    }

    [HttpGet("users")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _userService.GetAllAsync());
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromForm] UpdateUserDto dto)
    {
        var id = int.Parse(HttpContext.User.FindFirst("Id")!.Value);

        await _userService.UpdateAsync(id, dto);
        return Ok();
    }

    [HttpDelete("id")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _userService.DeleteAsync(id);
        return Ok();
    }
}
