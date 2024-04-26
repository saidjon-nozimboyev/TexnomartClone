using TexnomartClone.Application.DTOs.OrderDTOs;

namespace TexnomartClone.Application.Interfaces;

public interface IOrderService
{
    Task CreateAsync(AddOrderDto dto);
    Task DeleteAsync(int id);
    Task<OrderDto?> GetByIdAsync(int id);
    Task<IEnumerable<OrderDto>> GetAllAsync();
}