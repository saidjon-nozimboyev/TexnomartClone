using TexnomartClone.Domain.Entities;

namespace TexnomartClone.Application.DTOs.UserDTOs;

public class UserDto : AddUserDto
{
    public int Id { get; set; }     

    public static implicit operator UserDto(User user) 
    {
        return new UserDto()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Gender = user.Gender,
            Password = user.Password,
            PhoneNumber = user.PhoneNumber
        };
    }
}
