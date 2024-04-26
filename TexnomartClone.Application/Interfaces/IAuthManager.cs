using TexnomartClone.Domain.Entities;

namespace TexnomartClone.Application.Interfaces;

public interface IAuthManager
{
    string GenerateToken(User user);
}
