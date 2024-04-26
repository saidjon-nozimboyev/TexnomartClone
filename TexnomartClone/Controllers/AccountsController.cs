using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
}
