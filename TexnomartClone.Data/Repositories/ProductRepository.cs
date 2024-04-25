using TexnomartClone.Data.DbContexts;
using TexnomartClone.Data.Interfaces;
using TexnomartClone.Domain.Enums;

namespace TexnomartClone.Data.Repositories;

public class ProductRepository(AppDbContext dbContext) 
    : GenericRepository<Product>(dbContext), IProductRepository
{
    public Task<IEnumerable<Product>> GetByCategoryAsync(string categoryName)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByPriceAsync(double price)
    {
        throw new NotImplementedException();
    }
}
