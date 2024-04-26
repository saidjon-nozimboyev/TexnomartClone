using TexnomartClone.Data.DbContexts;
using TexnomartClone.Data.Interfaces;

namespace TexnomartClone.Data.Repositories;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext;

    public ICategoryRepository Category => new CategoryRepository(_dbContext);

    public IOrderRepository Order => new OrderRepository(_dbContext);

    public IProductRepository Product => new ProductRepository(_dbContext);

    public IUserRepository User => new UserRepository(_dbContext);
}
