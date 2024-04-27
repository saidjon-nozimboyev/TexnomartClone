using Microsoft.EntityFrameworkCore;
using TexnomartClone.Data.DbContexts;
using TexnomartClone.Data.Interfaces;
using TexnomartClone.Domain.Entities;

namespace TexnomartClone.Data.Repositories;

public class CategoryRepository(AppDbContext dbContext) 
    : GenericRepository<Category>(dbContext), ICategoryRepository
{
    public async Task<IEnumerable<Category?>> GetByNameAsync(string categoryName)
    {
        var categories = await _dbContext.Categories
                                        .Where(x => x.CategoryName == categoryName)
                                        .OrderBy(c => c.CategoryName)
                                        .ToListAsync();
        return categories;
    }

    public async Task<bool> IsCategoryExistsAsync(string categoryName)
    {
        var category = await _dbContext.Categories.FindAsync(categoryName);
        return category != null;
    }
}
