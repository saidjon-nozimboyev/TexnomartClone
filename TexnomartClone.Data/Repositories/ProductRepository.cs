using Microsoft.EntityFrameworkCore;
using TexnomartClone.Data.DbContexts;
using TexnomartClone.Data.Interfaces;
using TexnomartClone.Domain.Entities;
using TexnomartClone.Domain.Enums;

namespace TexnomartClone.Data.Repositories;

public class ProductRepository(AppDbContext dbContext) 
    : GenericRepository<Product>(dbContext), IProductRepository
{
    public async Task<IEnumerable<Product>> GetByCategoryAsync(string categoryName)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);

        return await _dbContext.Products.Where(p => p.CategoryId == category!.Id).ToListAsync();
    }

    public async Task<Product?> GetByPriceAsync(double price)
    {
        return await _dbContext.Products
            .FirstOrDefaultAsync(p => p.Price == price);
    }
}
