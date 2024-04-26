namespace TexnomartClone.Data.Interfaces;

public interface IUnitOfWork
{
    ICategoryRepository Category { get; }
    IOrderRepository Order { get; }
    IProductRepository Product { get; }
    IUserRepository User { get; }
}
