﻿using TexnomartClone.Domain.Entities;
using TexnomartClone.Domain.Enums;

namespace TexnomartClone.Application.DTOs.UserDTOs;

public class AddUserDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Gender Gender { get; set; }

    public static implicit operator User(AddUserDto dto)
    {
        return new User()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            Password = dto.Password,
            Gender = dto.Gender,
        };
    }
}