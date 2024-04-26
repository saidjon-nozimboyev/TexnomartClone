using TexnomartClone.Domain.Enums;

namespace TexnomartClone.Data.Interfaces;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product?> GetByPriceAsync(double price);
    Task<IEnumerable<Product>> GetByCategoryAsync(string categoryName);
}
