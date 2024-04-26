using TexnomartClone.Domain.Entities;

namespace TexnomartClone.Application.DTOs.CategoryDTOs;

public class CategoryDto : AddCategoryDto
{
    public int Id { get; set; } 

    public static implicit operator Category(CategoryDto dto)
    {
        return new Category()
        {
            Id = dto.Id,
            CategoryName = dto.CategoryName,
        };
    }

    public static implicit operator CategoryDto(Category category)
    {
        return new CategoryDto()
        {
            Id = category.Id,
            CategoryName = category.CategoryName,
        };
    }
}
