using System.Net;
using TexnomartClone.Application.Common.Exceptions;
using TexnomartClone.Application.DTOs.UserDTOs;
using TexnomartClone.Application.Interfaces;
using TexnomartClone.Data.Interfaces;
using TexnomartClone.Domain.Entities;

namespace TexnomartClone.Application.Services;

public class UserService(IUnitOfWork unitOfWork) : IUserService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;  

    public async Task DeleteAsync(int id)
    {
        var user = await _unitOfWork.User.GetByIdAsync(id);
        if (user is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");
        await _unitOfWork.User.DeleteAsync(user);

        throw new StatusCodeException(HttpStatusCode.OK, "User has been deleted sucessfully");
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _unitOfWork.User.GetAllAsync();
        return users.Select(x => (UserDto)x).ToList();
    }

    public async Task<UserDto> GetByIdAsync(int id)
    {
        var user = await _unitOfWork.User.GetByIdAsync(id);
        if (user is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");
        return (UserDto)user;
    }

    public async Task UpdateAsync(int id, UpdateUserDto dto)
    {

        var model = await _unitOfWork.User.GetByIdAsync(id);
        if (model is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");
        var user = (User)dto;
        user.Id = id;
        user.PhoneNumber = dto.PhoneNumber;
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Email = dto.Email;
        user.Gender = dto.Gender;

        await _unitOfWork.User.UpdateAsync(user);
        throw new StatusCodeException(HttpStatusCode.OK, "User has been updated sucessfully");
    }
}
