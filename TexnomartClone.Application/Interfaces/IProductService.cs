using TexnomartClone.Application.DTOs.OrderDTOs;
using TexnomartClone.Application.DTOs.ProductDTOs;
using TexnomartClone.Domain.Enums;

namespace TexnomartClone.Application.Interfaces;

public interface IProductService
{
    //Task<Product> GetByPriceAsync(double price);
    //Task<IEnumerable<Product>> GetByCategoryAsync(string categoryName);
    Task CreateAsync(AddProductDto dto);
    Task UpdateAsync(ProductDto dto);
    Task DeleteAsync(int id);
    Task<ProductDto?> GetByIdAsync(int id);
    Task<IEnumerable<ProductDto>> GetAllAsync();
}
