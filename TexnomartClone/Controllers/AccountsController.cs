using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TexnomartClone.Application.DTOs.UserDTOs;
using TexnomartClone.Application.Interfaces;

namespace TexnomartClone.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController(IAccountService accountService) : ControllerBase
{
    private readonly IAccountService _accountService = accountService;

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterAsync([FromForm] AddUserDto dto)
    {
        var result = await _accountService.RegisterAsync(dto);
        return Ok(result);
    }

    [HttpPost("login"), AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromForm] LoginDto dto)
    {
        var result = await _accountService.LoginAsync(dto);
        return Ok($"Token : {result}");
    }

    [HttpPost("sendcode")]
    public async Task<IActionResult> SendCodeAsync([FromForm] string email)
    {
        await _accountService.SendCodeAsync(email);
        return Ok();
    }

    [HttpPost("check")]
    public async Task<IActionResult> CheckCodeAsync([FromForm] string email, [FromForm] string password)
    {
        await _accountService.CheckCodeAsync(email, password);
        return Ok();
    }

    [HttpPatch("password")]
    public async Task<IActionResult> UpdatePasswordAsync(string password)
    {
        var email = HttpContext.User.FindFirst(ClaimTypes.Email)!.Value;
        await _accountService.UpdatePasswordAsync(email, password);
        return Ok();
    }
}
