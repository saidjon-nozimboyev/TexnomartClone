using TexnomartClone.Application.DTOs.UserDTOs;

namespace TexnomartClone.Application.Interfaces;

public interface IAccountService
{
    Task<bool> RegistrAsync(AddUserDto dto);
    Task<string> LoginAsync(LoginDto login);
}
