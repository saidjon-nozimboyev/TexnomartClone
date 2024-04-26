using TexnomartClone.Domain.Enums;

namespace TexnomartClone.Application.DTOs.ProductDTOs;

public class ProductDto : AddProductDto
{
    public int Id { get; set; }

    public static implicit operator ProductDto(Product product)
    {
        return new ProductDto()
        {
            CategoryId = product.CategoryId,
            Description = product.Description,
            Id = product.Id,
            Name = product.Name,
            Piece = product.Piece,
            Rating = product.Rating,
            Price = product.Price,
        };
    }

    public static implicit operator Product(ProductDto product) 
    {
        return new Product()
        {
            CategoryId = product.CategoryId,
            Description = product.Description,
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Rating = product.Rating,
            Piece = product.Piece
        };
    }
}
