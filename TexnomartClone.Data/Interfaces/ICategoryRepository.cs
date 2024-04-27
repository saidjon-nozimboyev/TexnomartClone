using TexnomartClone.Domain.Entities;

namespace TexnomartClone.Data.Interfaces;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<bool> IsCategoryExistsAsync(string categoryName);
    Task<IEnumerable<Category?>> GetByNameAsync(string categoryName);   
}
