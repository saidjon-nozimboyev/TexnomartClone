using TexnomartClone.Domain.Entities;

namespace TexnomartClone.Data.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<Order> GetOrderByDate(DateTime? date);
}
