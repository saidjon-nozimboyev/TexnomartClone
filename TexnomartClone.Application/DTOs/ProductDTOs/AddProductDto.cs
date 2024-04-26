using TexnomartClone.Domain.Enums;

namespace TexnomartClone.Application.DTOs.ProductDTOs;

public class AddProductDto
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Piece { get; set; }
    public double Rating { get; set; }

    public static implicit operator Product(AddProductDto dto)
    {
        return new Product()
        {
            CategoryId = dto.CategoryId,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Piece = dto.Piece,
            Rating = dto.Rating,
        };
    }
}
