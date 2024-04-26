using TexnomartClone.Domain.Entities;

namespace TexnomartClone.Application.DTOs.OrderDTOs;

public class AddOrderDto
{
    public int UserId { get; set; }
    public string OrderName { get; set; } = string.Empty;
    public DateTime OrderedDate { get; set; } = DateTime.UtcNow;

    public static implicit operator Order(AddOrderDto dto)
    {
        return new Order()
        {
            UserId = dto.UserId,
            OrderedDate = dto.OrderedDate,
            OrderName = dto.OrderName,
        };
    }
}
