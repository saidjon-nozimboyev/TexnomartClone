using TexnomartClone.Domain.Entities;

namespace TexnomartClone.Data.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}
