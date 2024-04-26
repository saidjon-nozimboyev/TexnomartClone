using TexnomartClone.Domain.Entities;

namespace TexnomartClone.Application.DTOs.CategoryDTOs;

public class AddCategoryDto
{
    public string CategoryName { get; set; } = string.Empty;

    public static implicit operator Category(AddCategoryDto dto)
    {
        return new Category()
        {
            CategoryName = dto.CategoryName,
        };
    }
}
