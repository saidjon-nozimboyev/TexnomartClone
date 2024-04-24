using TexnomartClone.Domain.Enums;

namespace TexnomartClone.Domain.Entities;

public class User : Base
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool IsVerified { get; set; } = false;
    public Gender Gender { get; set; }
    public Role Role { get; set; } = Role.User;
}
